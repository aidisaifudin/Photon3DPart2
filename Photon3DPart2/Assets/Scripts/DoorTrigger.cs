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

    }
   

    public void Update()
    {
        if (gotKey == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("gotKey");
            OpeningDoor();
        }
    }


   
    public void OpeningDoor()
    {
        //instructionPanel.SetActive(true);
        //doorAnim.SetBool("gotKey", true);
        pv.RPC("UpdatedDoorKey", RpcTarget.All);
    }

    [PunRPC]
    public void UpdatedDoorKey()
    {
        doorAnim.SetBool("gotKey", true);
    }
}

