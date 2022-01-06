using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class DeathCount : MonoBehaviour
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

        deathCounter = EnemyTarget.deathCount;
        ScoreText.text = deathCounter.ToString();
    }
}
