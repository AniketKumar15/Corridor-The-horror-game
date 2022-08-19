using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public Slider soundSlider;
    public AudioMixer audioMixer;


    public void SetVolume()
    {
        audioMixer.SetFloat("Sound", soundSlider.value);
    }
   
}
