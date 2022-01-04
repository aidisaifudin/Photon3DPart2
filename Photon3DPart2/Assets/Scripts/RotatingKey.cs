using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RotatingKey : MonoBehaviour
{
    public int rotatingSpeed;
    private bool pickUpAllowed;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotatingSpeed, 0, Space.World);
        if(pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
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
        Destroy(gameObject);
   
        Debug.Log("Key Gone");
    }
    public void UpdatedPickUp()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("PickUp", RpcTarget.AllBuffered);

    }
}
