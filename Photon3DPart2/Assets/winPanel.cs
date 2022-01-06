using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class winPanel : MonoBehaviourPun
{
    public PhotonView pv;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }



    public void PanelPopOut()
    {

        pv.RPC("RPC_ChangeScene", RpcTarget.All);


    }

    [PunRPC]
    public void RPC_ChangeScene()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel("Victory");
    }
}
