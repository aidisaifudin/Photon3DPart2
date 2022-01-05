using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RotatingKey : MonoBehaviourPun
{
    public int rotatingSpeed;
    private bool pickUpAllowed;
    private DoorTrigger door;
    public PhotonView pV;
    public GameObject doorFrame;
    public GameObject instructionKeyPanel;
    // Update is called once per frame
    public void Start()
    {
        pV = GetComponent<PhotonView>();
        door = doorFrame.GetComponent<DoorTrigger>();
        instructionKeyPanel.SetActive(false);

    }
    void Update()
    {
        transform.Rotate(0, rotatingSpeed, 0, Space.World);
       
            if (pickUpAllowed && Input.GetKeyDown(KeyCode.F))
            {
            PickUp();
            pV.RPC("PickUp", RpcTarget.All);
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == ("Player"))
        {
            pickUpAllowed = true;
            instructionKeyPanel.SetActive(true);
            Debug.Log("Key Here");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            pickUpAllowed = false;
           
        }
    }
    
    [PunRPC]
    public void PickUp()
    {
        door.gotKey = true;
        gameObject.SetActive(false);
        instructionKeyPanel.SetActive(false);

        Debug.Log("Key Gone");
    }
   
}
