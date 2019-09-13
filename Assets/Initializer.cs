using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] Music mainMusic = null;

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
