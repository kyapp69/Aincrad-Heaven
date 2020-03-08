using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource m_MyAudioSource;
    bool m_Play;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(m_Play)
        {
            m_MyAudioSource.Play();
        }
    }
}
