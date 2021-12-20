using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator myDoor = null;
    public bool openTrigger = false;
    public bool closeTrigger = false;

    public string doorOpen = "DoorOpen";
    public string doorClose = "DoorClose";

    public GameObject openPanel;



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(openTrigger)
            {
                myDoor.Play(doorOpen, 0, 0.0f);
            }

            else if (closeTrigger)
            {
                myDoor.Play(doorClose, 0, 0.0f); 
            }
        }
    }


}

