using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
   

public class AutoDoor : MonoBehaviourPun
{
    public Animator doorAnim;
    public PhotonView pv;

// Start is called before the first frame update
void Start()
    {
        doorAnim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "Player")
        {
            pv.RPC("OpeningDoor", RpcTarget.All);
            pv.RPC("ClosingDoor", RpcTarget.All);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        OpeningDoor();
    }

    public void nTriggerExit(Collider other)
    {
        ClosingDoor();
    }

    [PunRPC]
    public void OpeningDoor()
    {
        
        doorAnim.Play("DoorOpen");
    }

    [PunRPC]
    public void ClosingDoor()
    {

        doorAnim.Play("DoorClose");
    }

}
