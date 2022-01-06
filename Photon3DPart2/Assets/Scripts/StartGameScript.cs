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
           
            StartCoroutine(VictoryScene());
           
        }
    }
    [PunRPC]
    public void RPC_DefeatScene()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel("Defeat");
    }
    IEnumerator VictoryScene()
    {
        
        yield return new WaitForSeconds(10f);
        pv.RPC("RPC_DefeatScene", RpcTarget.All);
    }
}
