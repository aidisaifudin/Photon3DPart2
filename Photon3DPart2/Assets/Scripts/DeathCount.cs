using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class DeathCount : MonoBehaviourPun
{
    public int deathCounter;
    public Text ScoreText;
    public PhotonView pv;
    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        pv = GetComponent<PhotonView>();
    
    }

    // Update is called once per frame
    
    void Update()
    {
        
        pv.RPC("UpdateddeathCounter", RpcTarget.All);
        Debug.Log("enemy left :"+ deathCounter);
    }
    public void OnPhotonSerializeView()
    {

    }
    
    [PunRPC]
    public void UpdateddeathCounter()
    {
        Debug.Log("minus 1");
        deathCounter = EnemyTarget.deathCount;
        ScoreText.text = deathCounter.ToString();
    }
}
