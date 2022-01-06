using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class OnImpact : MonoBehaviourPun
{
    public PhotonView pv;
   // public GameObject impactEffect;

    public float damage = 25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collision)
    {
        
        //Instantiate(impactEffect, contact.point, Quaternion.LookRotation(contact.normal));

        if (collision.tag == "E")
        {
            Destroy(this.gameObject);
            // EnemyTarget target = collision.transform.gameObject.GetComponent<EnemyTarget>();
            //target.ApplyDamage(damage);
        }
        else if (collision.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
        
    }
}
