using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    meatLeft -= enemy.damage;
                    if (chompClip) {
                        SoundManager.Instance.PlayClip(chompClip);
                    }
                    if (meatLeft <= 0) {
                        meatLeft = 0;
                        Die();
                    }
                    invulnTimer.SetTime(invulnTime);
                }
            }
        }

    }

    void Die() {
        GameStateManager.Instance.GameOver();
    }
}
