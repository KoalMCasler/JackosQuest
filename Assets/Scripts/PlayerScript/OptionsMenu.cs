using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer MasterVolume;
    
    public TextMeshProUGUI masterVolumeText;
    public TextMeshProUGUI musicVolumeText;
    public TextMeshProUGUI sfxVolumeText;
    public void SetMasterVolume(float Volume)
    {
        Debug.Log(Volume);
        MasterVolume.SetFloat("MasterVolume", Volume);
        float DisplayVolume = 80 + Volume;
        masterVolumeText.text = string.Format("{0:0.0}%",DisplayVolume);
    }
    public void SetMusicVolume(float Volume)
    {
        Debug.Log(Volume);
        MasterVolume.SetFloat("MusicVolume", Volume);
        float DisplayVolume = 80 + Volume;
        musicVolumeText.text = string.Format("{0:0.0}%",DisplayVolume);
    }
    public void SetSFXVolume(float Volume)
    {
        Debug.Log(Volume);
        MasterVolume.SetFloat("SFXVolume", Volume);
        float DisplayVolume = 80 + Volume;
        sfxVolumeText.text = string.Format("{0:0.0}%",DisplayVolume);
    }
}
