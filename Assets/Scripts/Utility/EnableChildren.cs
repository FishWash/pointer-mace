using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Activates children in Awake(). Used for canvas elements

public class EnableChildren : MonoBehaviour
{
    void Awake() {
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
        }
    }
}
