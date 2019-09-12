using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public new Rigidbody2D rigidbody;
    public float moveSpeed = 5;
    Vector3 mouseLocation;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 300;
        transform.position = Vector3.zero;
        mouseLocation = transform.position;
    }

    void FixedUpdate()
    {

        //Update mouse position if it's within game
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHitInfo;
        if (Physics.Raycast(ray, out rayHitInfo, Mathf.Infinity)) {
            mouseLocation = rayHitInfo.point;
            // Debug.Log(rayHitInfo.point);
        }
        
        //Move
        rigidbody.MovePosition(
            Vector3.MoveTowards(
                transform.position,
                mouseLocation,
                moveSpeed
            )   
        );
    }
}
