using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RotatingKey : MonoBehaviour
{
    public int rotatingSpeed;
    private bool pickUpAllowed;
    private PhotonView pV;

    // Update is called once per frame
    public void Start()
    {
        PhotonView photonView = PhotonView.Get(this);
    }
    void Update()
    {
        //transform.Rotate(0, rotatingSpeed, 0, Space.World);
        if (pV.IsMine)
        {
            if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
            {
               // PickUp();
                pV.RPC("PickUp", RpcTarget.AllBuffered);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            pickUpAllowed = true;
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
        gameObject.SetActive(false);
   
        Debug.Log("Key Gone");
    }

}
