using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Hittable
{
    static bool debug = false;

    new Rigidbody2D rigidbody = null;
    new Collider collider = null;
    Animator animator = null;
    
    [SerializeField] float maxHealth = 50;
    [SerializeField] float basePoints = 0;
    [SerializeField] float pointsFactor = 1;
    [SerializeField] float baseMoveSpeed = 1;
    [SerializeField] float moveSpeedFactor = 0.5f;
    public int damage = 5;
    [SerializeField] GameObject dieEffect = null;

    [HideInInspector] public bool isAlive;
    float health, points, moveSpeed;

    void Start() 
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider>();
        animator = GetComponent<Animator>();
        isAlive = true;
        health = maxHealth;

        // Set stats according to wave
        int wave = AutoSpawner.Instance.wave;
        points = basePoints + pointsFactor*wave;
        moveSpeed = baseMoveSpeed + moveSpeedFactor*wave;
    }

    void Update() {
        if (isAlive) {
            MoveToCenter();
        }
    }

    void MoveToCenter() 
    {
        rigidbody.MovePosition(
            Vector3.MoveTowards(
                transform.position,
                Global.Instance.enemyGoal,
                moveSpeed * Time.deltaTime
            )
        );
    }

    public override void Hit(Vector3 velocity, float mass)
    {
        float damage = velocity.magnitude;
        if (debug)
            Debug.Log("Hit with " + damage);
        
        health -= damage;
        if (health < 0) {
            Die();
        }
    }

    void Die() 
    {
        isAlive = false;
        if (Global.gameState != Global.GameState.GameOver) {
            Global.points += points;
        }
        if (dieEffect) {
            GameObject go = Instantiate(dieEffect, transform.position, transform.rotation);
            go.transform.localScale = transform.localScale;
        }
        AutoSpawner.Instance.EnemyDied();
        Destroy(gameObject);
    }
}
