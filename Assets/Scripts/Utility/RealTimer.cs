using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimer : Timer
{
    public new bool isDone {
        get {
            return (endTime <= Time.realtimeSinceStartup);
        }
    }

    public new float timeLeft {
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

    public new void SetTime(float time) {
        endTime = Time.realtimeSinceStartup + time;
    }

    public new float GetTime() {
        return Mathf.Max(endTime - Time.realtimeSinceStartup, 0);
    }
}