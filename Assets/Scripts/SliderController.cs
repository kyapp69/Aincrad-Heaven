using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SliderController : MonoBehaviour
{
    public AudioMixer mixer;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
    }
}
