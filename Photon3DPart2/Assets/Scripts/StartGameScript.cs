using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class StartGameScript : MonoBehaviourPun
{
    public PhotonView pv;
    [PunRPC]
    public void StartGame()
    {
        Timer.timer.start = true;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Bullet")
        {
            pv.RPC("StartGame", RpcTarget.All);
        }
    }
}
