using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIConditionalDisplay : MonoBehaviour
{
    [SerializeField] Global.GameState gameStateToDisplayOn = 0;
    Global.GameState lastGameState = 0;

    void Update() {
        if (Global.gameState != lastGameState) {
            bool active = Global.gameState == gameStateToDisplayOn;
            foreach(Transform child in transform) {
                child.gameObject.SetActive(active);
            }
            lastGameState = Global.gameState;
        }
    }
}
