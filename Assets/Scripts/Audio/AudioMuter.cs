using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMuter : MonoBehaviour
{
    public bool isMusic = false;

    private AudioSource audioSource; // Audio Source
    private float baseVolume = 1f; // Базовая громкость


    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        baseVolume = audioSource.volume;
    }

    void Update()
    {
        if (isMusic)
        {
            //audioSource.volume = (AudioManager.music) ? baseVolume : 0f;
        }
        else
        {
            //audioSource.volume = (AudioManager.sounds) ? baseVolume : 0f;
        }
    }
}
