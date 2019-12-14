using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleZero : MonoBehaviour
{
    private bool timeStopped;
    
    void Start()
    {
        SetTimeScaleZero();
    }

    public void SetTimeScaleZero()
    {
        Time.timeScale = 0;
        timeStopped = true;
    }

    public void SetTimeScaleOne()
    {
        Time.timeScale = 1;
        timeStopped = false;
    }

    public void ToggleTime()
    {
        if (timeStopped)
        {
            SetTimeScaleOne();
        }
        else
        {
            SetTimeScaleZero();
        }
    }
}
