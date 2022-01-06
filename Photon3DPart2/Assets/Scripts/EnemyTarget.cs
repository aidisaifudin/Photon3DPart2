using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class EnemyTarget : MonoBehaviourPun
{
    public float health = 100f;
    public GameObject deadbody;
    private bool created = false;
    public float damage = 25f;
    public PhotonView pv;
    public static int deathCount = 10;
    
    

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
            ApplyDamage();
            deathCount -= 1;
            Debug.Log("Hit");
           

            //pv.RPC("Die", RpcTarget.All);

        }
      
    }

public void ApplyDamage()
    {
        pv.RPC("Die", RpcTarget.All);
        Debug.Log("Taking damage");
        Die();
    
    }
    [PunRPC]
    public void Die()
    {
        Debug.Log("Dead");
        gameObject.SetActive(false);
        
        
    }
}
