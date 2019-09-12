using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    new Rigidbody2D rigidbody = null;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Enemy")) {
            Hittable hittable = other.gameObject.GetComponent<Hittable>();
            if (hittable != null && rigidbody != null) {
                hittable.Hit(rigidbody.velocity, rigidbody.mass);
            }
        }
    }
}
