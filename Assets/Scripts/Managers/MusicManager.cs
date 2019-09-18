using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is used to play looping music.
*/

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    [SerializeField] public float musicVolume = 0.5f;
    AudioSource introSource, loopSource;

    void Awake() 
    {
        Instance = this;

        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 2) {
            introSource = audioSources[0];
            loopSource = audioSources[1];
            SetVolume(musicVolume);
        }
        else {
            Debug.LogError("[MusicManager] Not enough AudioSources");
        }
        
    }

    public static void Play(MusicFile music)
    {
        if (music.introClip && music.loopClip)
            Instance.PlayLoop(music.introClip, music.loopClip);
    }

        void PlayLoop(AudioClip introClip, AudioClip loopClip)
        {
            if (introSource != null && loopSource != null) {
                introSource.clip = introClip;
                loopSource.clip = loopClip;
                loopSource.loop = false;
                introSource.Play();
                Invoke("RepeatLoop", introClip.length);
            }
        }

        void RepeatLoop()
        {
            if (loopSource != null) {
                loopSource.Play();
                Invoke("RepeatLoop", loopSource.clip.length);
            }
        }

    public static void SetVolume(float newVolume) 
    {
        Instance._SetVolume(newVolume);
    }

        void _SetVolume(float newVolume) 
        {
            if (introSource && loopSource) {
                musicVolume = Mathf.Clamp(newVolume, 0, 1);
                introSource.volume = musicVolume;
                loopSource.volume = musicVolume;
            }
            else {
                Debug.LogError("[MusicManager] Can't find AudioSources");
            }
        }

    public void PauseMusic() {
        introSource.Pause();
        loopSource.Pause();
    }

    public void UnPauseMusic() {
        introSource.UnPause();
        loopSource.UnPause();
    }
}
