using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Manages sounds. Keeps sounds from playing at the same time by putting them in a queue to be played.
*/

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public static bool debug = true;

    [SerializeField] float soundVolume = 0.5f;
    [SerializeField] AudioClip punchClip = null;

    AudioSource soundSource = null;
    
    List<SoundFile> soundQueue = new List<SoundFile>();
    bool playedThisFrame = false;

    void Awake() {
        Instance = this;
        soundSource = GetComponent<AudioSource>();
        if (!soundSource) {
            Debug.LogError("[SoundManager] No source!");
        }
    }

    void Update() {
        if (soundQueue.Count > 0) {
            SoundFile sound = soundQueue[0];
            soundQueue.RemoveAt(0);
            soundSource.pitch = sound.pitch;
            soundSource.PlayOneShot(sound.clip, sound.volume * soundVolume);
            // soundSource.pitch = 1.0f;
        }
    }

    public void PlayClip(AudioClip clip) {
        PlayClip(clip, 1.0f, 1.0f);
    }

    public void PlayClip(AudioClip clip, float volume, float pitch) 
    {
        if (debug) {
            Debug.Log("Playing clip " + clip + " at " + volume + " volume and " + pitch + " pitch");
        }
        SoundFile sound = new SoundFile(clip, volume, pitch);
        soundQueue.Add(sound);

    }
}
