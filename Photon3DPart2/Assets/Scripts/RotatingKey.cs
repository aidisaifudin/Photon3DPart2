using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RotatingKey : MonoBehaviourPun
{
    public int rotatingSpeed;
    private bool pickUpAllowed;
     public PhotonView pV;

    // Update is called once per frame
    public void Start()
    {
        pV = GetComponent<PhotonView>();
    }
    void Update()
    {
        //transform.Rotate(0, rotatingSpeed, 0, Space.World);
       
            if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
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
    public void UpdatedPickUp()
    {
       // PhotonView photonView = PhotonView.Get(this);
       // pV.RPC("PickUp", RpcTarget.AllBuffered, null);
    }
}
