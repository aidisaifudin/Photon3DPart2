using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public bool action;
    
    //public bool openTrigger = false;
    //public bool closeTrigger = false;

    //public string doorOpen = "DoorOpen";
    //public string doorClose = "DoorClose";
    public GameObject door;
    public GameObject openPanel;

    private void Start()
    {
        openPanel.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            openPanel.gameObject.SetActive(true);
            action = true;
        }
    }

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
                openPanel.gameObject.SetActive(false);
                door.GetComponent<Animator>().Play("DoorOpen");
                action = false;
            }
        }
    }

}

