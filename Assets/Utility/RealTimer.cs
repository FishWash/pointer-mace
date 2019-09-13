using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimer : Timer
{
    public bool isDone {
        get {
            return (endTime <= Time.realtimeSinceStartup);
        }
    }

    public float timeLeft {
        get {
            return Mathf.Max(endTime - Time.realtimeSinceStartup, 0);
        }
        set {
            endTime = Time.realtimeSinceStartup + value;
        }
    }

    public RealTimer() {
        endTime = 0;
    }

    public RealTimer(float time) {
        endTime = Time.realtimeSinceStartup + time;
    }

    public void SetTime(float time) {
        endTime = Time.realtimeSinceStartup + time;
    }

    public float GetTime() {
        return Mathf.Max(endTime - Time.realtimeSinceStartup, 0);
    }
}