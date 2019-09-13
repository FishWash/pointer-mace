using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBlinking : MonoBehaviour
{
    [SerializeField] float blinkTime = 1.0f;

    Text text;
    RealTimer blinkTimer;

    void Start() {
        text = GetComponent<Text>();
        blinkTimer = new RealTimer();
    }

    void Update() {
        if (blinkTimer.isDone) {
            text.enabled = !text.enabled;
            blinkTimer.SetTime(blinkTime);
        }
    }
}
