using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class MainMenu : MonoBehaviourPun
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        SceneManager.LoadScene("GameLauncherScene");
    }
    public void Instruction()
    {
        SceneManager.LoadScene("Instruction");
    }
    public void Credit()
    {
        SceneManager.LoadScene("CreditScene");
    }
    public void Exit()
    {
        
        

        Application.Quit();
    }
    public void Main()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
