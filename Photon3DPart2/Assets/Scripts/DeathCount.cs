using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class DeathCount : MonoBehaviourPun
{
    private static int deathCounter;
    public Text ScoreText;
    public PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
    
    }

    // Update is called once per frame
    
    void Update()
    {
        DeathCounter();
        

    }
    public void OnPhotonSerializeView()
    {

    }
    public void DeathCounter()
    {
        deathCounter = EnemyTarget.deathCount;
        ScoreText.text = deathCounter.ToString();
        pv.RPC("UpdateddeathCounter", RpcTarget.AllBufferedViaServer);

    }
    [PunRPC]
    public void UpdateddeathCounter()
    {
        Debug.Log("minus 1");
        //deathCounter = EnemyTarget.deathCount;
        ScoreText.text = deathCounter.ToString();
    }
}
