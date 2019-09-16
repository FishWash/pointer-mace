using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] AudioClip chompClip = null;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Global.gameState = Global.GameState.GameOver;
            if (chompClip) {
                SoundManager.Instance.PlayClip(chompClip);
            }
        }
    }
}
