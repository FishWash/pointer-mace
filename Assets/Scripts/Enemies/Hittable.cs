using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hittable : MonoBehaviour
{
    public abstract void Hit(Vector3 velocity, float mass);
}
