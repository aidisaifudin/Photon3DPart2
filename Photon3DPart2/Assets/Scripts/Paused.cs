using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : MonoBehaviour
{
    public GameObject pausedPanel;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                
                Time.timeScale = 0;
                pausedPanel.gameObject.SetActive(true);
                
            }
            else
            {
                Time.timeScale = 1;
                pausedPanel.gameObject.SetActive(false);
            }
           
            
        }
        
        
        
    }

}
