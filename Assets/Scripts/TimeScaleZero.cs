using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleZero : MonoBehaviour
{
    private bool timeStopped;
    // Start is called before the first frame update
    void Start()
    {
        SetTimeScaleZero();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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
}
