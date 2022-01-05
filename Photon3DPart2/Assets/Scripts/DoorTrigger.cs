using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class DoorTrigger : MonoBehaviourPun
{
    public bool action;
   
    public GameObject door;
    public GameObject openPanel;
    public GameObject triggerCube;

    private void Start()
    {
        door.GetComponent<Animator>();
        openPanel.gameObject.SetActive(false);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            openPanel.gameObject.SetActive(true);
            action = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (action == true)
                {


                    openPanel.gameObject.SetActive(false);
                    door.GetComponent<Animator>().Play("DoorOpen");
                    action = false;
                    triggerCube.gameObject.SetActive(false);

                }
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        openPanel.gameObject.SetActive(false);
        action = false;
    }
   
    
}

