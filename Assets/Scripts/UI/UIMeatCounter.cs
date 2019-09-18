using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMeatCounter : MonoBehaviour
{
    [SerializeField] Goal goal = null;
    [SerializeField] string prefix = "";
    [SerializeField] bool gradualChange = false;

    Text text = null;
    int displayValue = 0;

    void Start() {
        text = GetComponent<Text>();
        displayValue = goal.meatLeft;
    }

    void Update() 
    {
        if (!text) return;
        if (!goal) return;

        if (gradualChange) {
            if (displayValue != goal.meatLeft) {
                displayValue += (int)Mathf.Sign(goal.meatLeft - displayValue);
            }
        }
        else {
            displayValue = goal.meatLeft;
        }

        text.text = prefix + displayValue.ToString("n0");
    }
}
