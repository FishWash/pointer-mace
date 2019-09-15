using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Hittable
{
    static bool debug = false;

    new Rigidbody2D rigidbody = null;
    
    [SerializeField] float maxHealth = 50;
    [SerializeField] float pointValue = 1;
    [HideInInspector] public bool isAlive;
    float health;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        isAlive = true;
        health = maxHealth;
    }

    void Update() {
    }

    public override void Hit(Vector3 velocity, float mass) {
        float damage = velocity.magnitude;
        if (debug)
            Debug.Log("Hit with " + damage);
        
        health -= damage;
        if (health < 0) {
            Die();
        }
    }

    void Die() {
        isAlive = false;
        Global.points += pointValue * AutoSpawner.Instance.wave;
        Destroy(gameObject);
    }
}
