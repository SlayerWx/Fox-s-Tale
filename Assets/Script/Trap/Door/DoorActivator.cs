using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    [SerializeField] GifLoop[] doors;
    int count;
    private void Start()
    {
        count = 0;
    }
    public void ButtonActivated()
    {
        count++;
        if (count == doors.Length)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].StartAnim();
            }
        }
    }
}
