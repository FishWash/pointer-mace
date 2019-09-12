using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPointsDisplay : MonoBehaviour
{
    [SerializeField] string prefix = "";
    [SerializeField] bool gradualIncrease;

    Text text;
    float displayPoints = 0;

    void Start() {
        text = GetComponent<Text>();
        displayPoints = Global.points;
    }

    void Update() {
        if (!text) return;
        if (!Global.Instance) return;

        if (gradualIncrease) {
            if (displayPoints < Global.points) {
                displayPoints++;
            }
        }
        else {
            displayPoints = Global.points;
        }

        text.text = prefix + displayPoints.ToString("n0");
    }
}
