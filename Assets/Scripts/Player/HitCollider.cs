using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is the head of the mace. Handles collisions with enemies.
*/

public class HitCollider : MonoBehaviour
{
    new Rigidbody2D rigidbody = null;
    [SerializeField] AudioClip punchClip = null;
    [SerializeField] float pitchMult = 0.05f;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Enemy")) 
        {
            Hittable hittable = other.gameObject.GetComponent<Hittable>();
            if (hittable != null && rigidbody != null && rigidbody.velocity.magnitude > 10.0f) 
            {
                //Damage the enemy
                hittable.Hit(rigidbody.velocity, rigidbody.mass);
                // Make a hit spark
                Quaternion hitsparkRotation = Quaternion.identity;
                hitsparkRotation.SetLookRotation(rigidbody.velocity);
                Global.InstantiateHitspark(transform.position, hitsparkRotation);
                // Play sound
                float pitch = (30 + rigidbody.velocity.magnitude*0.3f) * pitchMult;
                SoundManager.Instance.PlayClip(punchClip, 1.0f, pitch);
                Debug.Log("[HitCollider] Hit for " + rigidbody.velocity.magnitude);
            }
        }
    }
}
