using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public float health = 100f;
    public GameObject deadbody;
    private bool created = false;
    public float damage = 25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit");
            EnemyTarget target = collision.transform.gameObject.GetComponent<EnemyTarget>();
            target.ApplyDamage(damage);
        }
    }
public void ApplyDamage(float amount)
    {
        health -= Mathf.Abs(amount);
        if (health < 0 )
        {

            Destroy(gameObject);
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
