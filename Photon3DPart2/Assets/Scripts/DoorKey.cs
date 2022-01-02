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
            GUI.Box(new Rect(0, 60, 200, 25), "Press E to take key");
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorScripts.doorKey = true;
                
            }
        }
    }
    [PunRPC]
    public void TakeKey()
    {
        DoorScripts.doorKey = true;
        Destroy(this.gameObject);
        Destroy(this.gameObject); PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("TakeKey", RpcTarget.All);
    }

    void OnGUI()
    {
        if (inTrigger)
        {
            GUI.Box(new Rect(0, 60, 200, 25), "Press E to take key");
        }
    }
}
