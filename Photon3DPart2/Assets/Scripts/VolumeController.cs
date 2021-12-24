using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeController : MonoBehaviour
{
    public Slider musicSlider;
    
    public AudioSource music;
    public TextMeshProUGUI volumeTextUI = null;

    public void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume"); //get music playerpref
        
    }

    public void Update()
    {
        music.volume = musicSlider.value;
    }

    public void VolumeSlider(float volume)
    {
        volumeTextUI.text = volume.ToString("0.0");
    }

    public void VolumePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", music.volume);
    }


    
}
