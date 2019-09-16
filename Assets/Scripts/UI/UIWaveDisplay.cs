using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWaveDisplay : MonoBehaviour
{
    [SerializeField] string prefix = "";

    Text text;

    void Start() {
        text = GetComponent<Text>();
    }

    void Update() {
        if (!text) return;
        if (!AutoSpawner.Instance) return;
        text.text = prefix + AutoSpawner.Instance.wave;
    }
}
