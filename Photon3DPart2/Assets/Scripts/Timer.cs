using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviourPun
{
    public static Timer timer;
    public float timeLeft;
    public Text countdownText;
    public bool start=false;
    public PhotonView pv;
    public GameObject openPanel;

    // Start is called before the first frame update
    void Start()
    {
        timer = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timeLeft -= Time.deltaTime;

        }
        if (timeLeft <= 0)
        {
            //Debug.Log("Defeat");
            timeLeft = 0;
            if(timeLeft == 0)
            {
                openPanel.SetActive(true);
                //Time.timeScale = 0;
            }
          
        }

        countdownText.text = timeLeft.ToString("Time Left = " + "0" );
    }

    
}
