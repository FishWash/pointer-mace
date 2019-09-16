using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] float soundVolume = 0.5f;
    [SerializeField] AudioClip punchClip = null;

    AudioSource soundSource = null;

    void Awake() {
        Instance = this;
        soundSource = GetComponent<AudioSource>();
        if (!soundSource) Debug.LogError("[SoundManager] No source!");
    }

    public void PlayClip(AudioClip clip) {
        PlayClip(clip, 1.0f, 1.0f);
    }

    public void PlayClip(AudioClip clip, float volume, float pitch) {
        if (soundSource && clip) {
            soundSource.pitch = pitch;
            soundSource.PlayOneShot(clip, soundVolume*volume);
        }
        else {
            Debug.LogError("[SoundManager] No punch clip");
        }
    }
}
