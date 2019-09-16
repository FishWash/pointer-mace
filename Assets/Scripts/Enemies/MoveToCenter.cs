using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCenter : MonoBehaviour
{
    new Rigidbody2D rigidbody;
    [SerializeField] float moveSpeed = 1;
    Enemy myEnemy;

    void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
        myEnemy = GetComponent<Enemy>();
    }

    void Update() 
    {
        if (myEnemy) {
            if (!myEnemy.isAlive) {
                return;
            }
        }

        //Move
        rigidbody.MovePosition(
            Vector3.MoveTowards(
                transform.position,
                Global.Instance.enemyGoal,
                moveSpeed * Time.deltaTime
            )
        );
    }
}
