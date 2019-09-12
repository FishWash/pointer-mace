using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Hittable
{
    static bool debug = false;

    new Rigidbody2D rigidbody = null;
    
    [SerializeField] float maxHealth = 50;
    [SerializeField] float pointValue = 1;
    float health;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    public override void Hit(Vector3 velocity, float mass) {
        float damage = velocity.magnitude;
        if (debug)
            Debug.Log("Hit with " + damage);
        
        health -= damage;
        if (health < 0) {
            Debug.Log("Givin " + pointValue * AutoSpawner.Instance.wave + " points");
            Global.points += pointValue * AutoSpawner.Instance.wave;
            Destroy(gameObject);
        }
    }
}
