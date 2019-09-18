using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Used for keeping track of clips with their volume and pitch.
*/

public class SoundFile 
{
    public AudioClip clip;
    public float volume;
    public float pitch = 1.0f;

    public SoundFile(AudioClip clip) {
        this.clip = clip;
        volume = 1.0f;
        pitch = 1.0f;
    }

    public SoundFile(AudioClip clip, float volume, float pitch) {
        this.clip = clip;
        this.volume = volume;
        this.pitch = pitch;
    }
}