using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;
using Photon.Realtime;


public class EnemyRunAway : MonoBehaviourPun
{
    public NavMeshAgent _agent;
    public GameObject enemy;
    public float enemyRunDist;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, enemy.transform.position);

        Debug.Log("Distance: " +  distance);

        //run away from player
        if(distance < enemyRunDist)
        {
            Vector3 dirToEnemy = transform.position - enemy.transform.position; //vector enemy to me

            Vector3 newPos = transform.position + dirToEnemy;

            _agent.SetDestination(newPos);
        }

    }
}
