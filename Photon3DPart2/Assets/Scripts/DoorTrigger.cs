using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class DoorTrigger : MonoBehaviourPun
{
    public bool gotKey;
    public GameObject instructionPanel;
    public RotatingKey key;
    public Animator doorAnim;
    public PhotonView pv;

    public void Start()
    {
        gotKey = false;
        instructionPanel.SetActive(false);
        doorAnim.GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (gotKey && Input.GetKeyDown(KeyCode.E))
        {
            OpeningDoor();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        instructionPanel.SetActive(false);
    }

    public void Update()
    {
        if(gotKey && Input.GetKeyDown(KeyCode.E))
        {
            //OpeningDoor();
           // doorAnim.Play("DoorOpen");
            pv.RPC("OpeningDoor", RpcTarget.All);
        }
    }


    [PunRPC]
    public void OpeningDoor()
    {
        instructionPanel.SetActive(true);
        doorAnim.Play("KeyDoorOpen");
    }

}

