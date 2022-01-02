using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DoorTrigger : MonoBehaviour
{
    public bool action;
    
    //public bool openTrigger = false;
    //public bool closeTrigger = false;

    //public string doorOpen = "DoorOpen";
    //public string doorClose = "DoorClose";
    public GameObject door;
    public GameObject openPanel;
    public GameObject triggerCube;

    private void Start()
    {
        openPanel.gameObject.SetActive(false);
    }
    [PunRPC]
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            openPanel.gameObject.SetActive(true);
            action = true;
        }
    }
    [PunRPC]
    void OnTriggerExit(Collider other)
    {
        openPanel.gameObject.SetActive(false);
        action = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(action == true)
            {
                PhotonView photonView = PhotonView.Get(this);
                photonView.RPC("DoorOpen", RpcTarget.All);
                openPanel.gameObject.SetActive(false);
                door.GetComponent<Animator>().Play("DoorOpen");
                action = false;
                triggerCube.gameObject.SetActive(false);

            }
        }
    }

}

