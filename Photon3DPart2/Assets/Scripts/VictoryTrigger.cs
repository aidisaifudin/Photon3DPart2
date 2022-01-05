using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviourPun
{
    public PhotonView pv;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator VictoryScene(float waitTime)
    {
       

        yield return new WaitForSeconds(waitTime);
    }

    public void OnTriggerEnter(Collider other)
    {
           if (other.tag == "Player")
        {
            pv.RPC("RPC_ChangeScene", RpcTarget.All);
            StartCoroutine(VictoryScene(2f));
        }
           
    }

    [PunRPC]
    public void RPC_ChangeScene()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel("Victory");
    }
}
