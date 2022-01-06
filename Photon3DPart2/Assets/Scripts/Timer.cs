using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Timer : MonoBehaviourPun
{
    public int timeLeft;
    public Text countdownText;
    public PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
       
        pv.RPC("LoseTime", RpcTarget.All);
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("Time Left = " + timeLeft);

       
         if (timeLeft < 0)
        {
            StopCoroutine("LoseTime");
            
            countdownText.text = "Times Up!";
        }
    }

    [PunRPC]
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
