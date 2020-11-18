using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{
    public static bool timeStopped = false;
    void OnEnable()
    {
        PlayerMove.TimeState += StopTheTime;
    }
    void OnDisable()
    {
        PlayerMove.TimeState -= StopTheTime;
    }
    void StopTheTime()
    {
        timeStopped = !timeStopped;
        Debug.Log(timeStopped);
    }
    public static bool GetTimeStatus()
    {
        return timeStopped;
    }


}
