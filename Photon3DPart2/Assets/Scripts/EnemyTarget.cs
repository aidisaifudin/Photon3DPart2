using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyTarget : MonoBehaviourPun
{
    public float health = 100f;
    public GameObject deadbody;
    private bool created = false;
    public float damage = 25f;
    public PhotonView pv;
    public static float deathCount;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject[] enemiesCount;
  



    // Start is called before the first frame update
    void Start()
    {
  
        
    }

    // Update is called once per frame
    void Update()
    {
        if (deathCount == 1)
        {
            
            pv.RPC("RPC_ChangeScene", RpcTarget.All);
        }
        Debug.Log("DeathCount"+deathCount);
        
        
    }
    [PunRPC]
    public void RPC_ChangeScene()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel("Victory");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            ApplyDamage();

            Debug.Log("Hit");


            //pv.RPC("Die", RpcTarget.All);

        }
    }

 
    public void ApplyDamage()
    {
        pv.RPC("Die", RpcTarget.All);
        Debug.Log("Taking damage");
        //Die();
    
    }
    [PunRPC]
    public void Die()
    {
       
        Debug.Log("Dead");
        deathCount += 1;
        Destroy(this.gameObject);
        

    }
    

}
