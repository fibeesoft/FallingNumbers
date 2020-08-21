using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] backgroundSounds;
    bool isSoundOn;
    public bool IsSoundOn { get { return isSoundOn; } }
    AudioSource audios;
    void Start()
    {
        audios = GetComponent<AudioSource>();
        isSoundOn = true;
        ChooseBgSound(0);

    }

    void Update()
    {
        if(isSoundOn && !audios.isPlaying)
        {
            audios.Play();
        }else if (!isSoundOn)
        {
            audios.Stop();
        }
    }

    public void ChooseBgSound(int clipNumber)
    {
        audios.clip = backgroundSounds[clipNumber];
    }

    public void SwitchSoundsOnOff()
    {
        if (isSoundOn)
        {
            isSoundOn = false;
        }
        else
        {
            isSoundOn = true;
        }
    }
}
