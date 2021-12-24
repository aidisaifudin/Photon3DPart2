using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using Photon.Voice.PUN;

public class PushToTalk : MonoBehaviour
{
    public KeyCode PushButton = KeyCode.P;
    public Recorder VoiceRecorder;
    private PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        //view = photonView;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
