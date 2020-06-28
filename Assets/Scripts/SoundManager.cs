using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;
    public AudioSource audioSource;
    public AudioClip jump, hurted, collection;

    private void Awake()
    {
        soundManager = this;
    }

    public void PlayAudio(string type)
    {
        if (type == "jump")
        {
            audioSource.clip = jump;
        }else if (type == "hurted")
        {
            audioSource.clip = hurted;
        }else if (type == "collection")
        {
            audioSource.clip = collection;
        }
        audioSource.Play();
    }

}
