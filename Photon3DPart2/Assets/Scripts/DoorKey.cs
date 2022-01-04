using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(PhotonAnimatorView))]

public class DoorKey : MonoBehaviour
{
    PhotonView pV;
    public bool inTrigger;

    void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
    [PunRPC]
    void Update()
    {
        if (inTrigger)
        {
            
        }
    }

    public void OnTriggerEnter(Collision other)
    {
        if (gameObject.tag == "Player")
        {
            Debug.Log("Hi");
          
            TakeKey();
          
        }
    }
    [PunRPC]
    public void TakeKey()
    {
        Debug.Log("Take Key");
        DoorScripts.doorKey = true;
        Destroy(this.gameObject);
        Destroy(this.gameObject); PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("TakeKey", RpcTarget.All);
    }

    void OnGUI()
    {
   
    }
}
