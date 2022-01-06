using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
   

public class AutoDoor : MonoBehaviour
{
    public Animator doorAnim;
    public PhotonView pv;

// Start is called before the first frame update
     public void Start()
    {
        doorAnim.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            pv.RPC("OpeningDoor", RpcTarget.AllBuffered);
        }
        else
        {
            Debug.Log("Nothing");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            pv.RPC("ClosingDoor", RpcTarget.AllBuffered);
        }
        else
        {
            Debug.Log("Nothing");
        }
    }

    [PunRPC]
    public void OpeningDoor()
    {

        doorAnim.SetBool("open", true);
    }

    [PunRPC]
    public void ClosingDoor()
    {

        doorAnim.SetBool("open", false);
    }

}
