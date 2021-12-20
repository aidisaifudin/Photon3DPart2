using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private Animator _animator;

    public GameObject openPanel = null;

    private bool isInsideTrigger = false;


     void Start()
    {
        _animator = transform.Find("Door").GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isInsideTrigger = true;
            openPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isInsideTrigger = false;
            _animator.SetBool("open", false);
            openPanel.SetActive(false);
        }
    }

    private bool isOpenPanelActive
    {
        get
        {
            return openPanel.activeInHierarchy;
        }
    }

    void Update()
    {
        if(isOpenPanelActive && isInsideTrigger)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                openPanel.SetActive(false);
                _animator.SetBool("open", true);
            }
        }
    }
}
