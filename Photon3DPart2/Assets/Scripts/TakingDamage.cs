using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class TakingDamage : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Image healthBar;

    private float health;
    public float startHealth = 100;
    

    // Start is called before the first frame update
    void Start()
    {


        health = startHealth;

        healthBar.fillAmount = health/startHealth;
        PhotonView photonView = PhotonView.Get(this);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [PunRPC]
    public void TakeDamage(float _damage)
    {
        
        health -= _damage;
        Debug.Log(health);

        healthBar.fillAmount = health / startHealth;

        if (health<=0f)
        {
            //Die
            Die();
        }
      

    }


    void Die()
    {
        if (photonView.IsMine)
        {
            PhotonView photonView = PhotonView.Get(this);
            photonView.RPC("Die", RpcTarget.All);
            PixelGunGameManager.instance.LeaveRoom();
        }
      
    }
}
