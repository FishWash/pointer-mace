using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is the thing the Player is protecting from the enemies.
If an enemy collides with this, it loses meat points!
*/


public class Goal : MonoBehaviour
{
    [SerializeField] AudioClip chompClip = null;
    public int meatLeft = 100;
    [SerializeField] float invulnTime = 1.0f;
    Timer invulnTimer;

    void Start() {
        invulnTimer = new Timer();
    }

    void OnCollisionStay2D(Collision2D other) 
    {
        if (meatLeft > 0 && invulnTimer.isDone) 
        {
            if (other.gameObject.CompareTag("Enemy")) 
            {
                Enemy enemy = other.gameObject.GetComponent<Enemy>();
                if (enemy) {
                    // Take damage to meat
                    meatLeft -= enemy.damage;
                    // Play sound
                    if (chompClip) {
                        SoundManager.Instance.PlayClip(chompClip);
                    }
                    // Check if game over
                    if (meatLeft <= 0) {
                        meatLeft = 0;
                        Die();
                    }
                    // Start invulnerability timer
                    invulnTimer.SetTime(invulnTime);
                }
            }
        }

    }

    void Die() {
        GameStateManager.Instance.GameOver();
    }
}
