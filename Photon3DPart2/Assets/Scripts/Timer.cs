using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Timer : MonoBehaviourPun
{
    public static Timer timer;
    public float timeLeft;
    public Text countdownText;
    public bool start=false;

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
        else if (timeLeft < 0)
        {
            timeLeft = 0;
            Debug.Log("Victory");
        }

        countdownText.text = ("Time Left = " + timeLeft);
    }
}
