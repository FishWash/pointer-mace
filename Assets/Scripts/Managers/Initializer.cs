using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Does startup stuff
*/

public class Initializer : MonoBehaviour
{
    [SerializeField] MusicFile mainMusic = null;

    // Start is called before the first frame update
    void Start()
    {
        if (mainMusic) {
            MusicManager.Play(mainMusic);
        }
        else {
            Debug.LogError("[Initializer] No music");
        }
    }
}
