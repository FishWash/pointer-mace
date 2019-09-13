using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (hittable != null && rigidbody != null && rigidbody.velocity.magnitude > 10.0f) {
                hittable.Hit(rigidbody.velocity, rigidbody.mass);
                Quaternion hitsparkRotation = Quaternion.identity;
                hitsparkRotation.SetLookRotation(rigidbody.velocity);
                Global.InstantiateHitspark(transform.position, hitsparkRotation);
                SoundManager.Instance.PlayClip(punchClip, 1.0f, rigidbody.velocity.magnitude * pitchMult);
            }
        }
    }
}
