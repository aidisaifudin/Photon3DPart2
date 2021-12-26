using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
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
        SceneManager.LoadScene("GameLauncher");
    }
    public void Instruction()
    {
        SceneManager.LoadScene("Instruction");
    }
    public void Credit()
    {
        SceneManager.LoadScene("Credit");
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