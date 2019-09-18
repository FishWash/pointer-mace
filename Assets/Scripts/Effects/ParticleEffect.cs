using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
ParticleEffect destroys itself after a set period of time. 
*/

public class ParticleEffect : MonoBehaviour
{
    public float lifeTime = 1.0f;
    // new ParticleSystem particleSystem = null;

    void Start() {
        // particleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, lifeTime);
    }
}
