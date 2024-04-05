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
    
    public TextMeshProUGUI volumeText;
    public void SetVolume(float Volume)
    {
        Debug.Log(Volume);
        MasterVolume.SetFloat("MasterVolume", Volume);
        float DisplayVolume = 80 + Volume;
        volumeText.text = string.Format("{0:0.0}%",DisplayVolume);
    }
}
