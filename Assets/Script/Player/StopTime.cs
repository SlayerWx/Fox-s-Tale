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
    void StopTheTime(bool w)
    {
        timeStopped = w;
    }
    public static bool GetTimeStatus()
    {
        return timeStopped;
    }


}
