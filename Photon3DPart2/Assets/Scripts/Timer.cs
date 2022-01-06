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
    public PhotonView pv;

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
            pv.RPC("RPC_DefeatScene", RpcTarget.All);
            Debug.Log("Defeat");
        }

        countdownText.text = timeLeft.ToString("Time Left = " + "0" );
    }

    [PunRPC]
    public void RPC_DefeatScene()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel("Defeat");
    }
}
