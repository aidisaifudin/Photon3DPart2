using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class DeathCount : MonoBehaviourPun
{
    public float deathCounter;
    public Text ScoreText;
    public PhotonView pv;
    public GameObject winPanel;

    // Start is called before the first frame update
    void Start()
    {
    
        pv = GetComponent<PhotonView>();
    
    }

    // Update is called once per frame
    
    void Update()
    {
        
        pv.RPC("UpdateddeathCounter", RpcTarget.All);
        if (deathCounter == 2)
        {
            winPanel.SetActive(true);
        }

    }
    public void OnPhotonSerializeView()
    {

    }
 
    
    [PunRPC]
    public void UpdateddeathCounter()
    {
        
        deathCounter = EnemyTarget.deathCount;
        ScoreText.text = deathCounter.ToString();
    }
}
