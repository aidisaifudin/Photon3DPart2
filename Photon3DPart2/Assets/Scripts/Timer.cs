using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Timer : MonoBehaviourPun
{
    public float timeLeft;
    public Text countdownText;
    public PhotonView pv;
    public static Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = this;
       // pv.RPC("LoseTime", RpcTarget.All);
    }

    // Update is called once per frame
    void Update()
    {
        

       // pv.RPC("LoseTime", RpcTarget.All);
        
    }

    [PunRPC]
    public void LoseTime()
    {
        if (timeLeft > 0 )
        {
            timeLeft -= Time.deltaTime;

        }
        else if (timeLeft < 0)
        {
            Debug.Log("Victory");
        }
        countdownText.text = ("Time Left = " + timeLeft);
    }
}
