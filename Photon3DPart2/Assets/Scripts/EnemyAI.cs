using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;

public class EnemyAI : MonoBehaviourPun
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject projectile;

    public GameObject enemy;

    public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform; //find player
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //check for sight or attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling(); // if player not in sight range, he patrol
        if (playerInSightRange && !playerInAttackRange) ChasePlayer(); // if player is in sight range but not in attack range, chase player
        if (playerInAttackRange && playerInAttackRange) AttackPlayer(); // if player is in sight and attack range, starts attacking

    }

    private void Patroling()
    {
        

        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);
            enemy.GetComponent<Animator>().Play("Patrol");

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ); //random walkpoints

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true; //to make sure walkpoint is grounded

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        enemy.GetComponent<Animator>().Play("Chase");
    }

    private void AttackPlayer()
    {
        //make sure enemy does not move
        agent.SetDestination(transform.position);
        enemy.GetComponent<Animator>().Play("Shoot");
        //PhotonView photonView = PhotonView.Get(this);
        //photonView.RPC("Shoot", RpcTarget.All);
        transform.LookAt(player); // look at player when shoot

        if(!alreadyAttacked)
        {
           // projectile.transform.position = new Vector3(1f, 1f, 0);
            //attack code
            Rigidbody rb = Instantiate(projectile,transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 30f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);
            

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

            
        }

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);

    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
