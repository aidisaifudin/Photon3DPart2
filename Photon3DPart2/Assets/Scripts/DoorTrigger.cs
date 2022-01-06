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
        instructionPanel.SetActive(true);
    }

    public void OnTriggerExit(Collider other)
    {
        instructionPanel.SetActive(false);
        if (gotKey)
        {
            Debug.Log("gotKey");
            pv.RPC("OpeningDoor", RpcTarget.All);
        }
    }

    public void Update()
    {
      
    }


    [PunRPC]
    public void OpeningDoor()
    {
        instructionPanel.SetActive(true);
        doorAnim.SetBool("gotKey", false);
    }

}

