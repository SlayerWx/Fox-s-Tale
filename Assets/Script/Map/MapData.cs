using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour //asAS
{
    [SerializeField] private Transform start = null;
    [SerializeField] private Transform end = null;
    public Vector3 GetCoordsStart()
    {
        if (start == null) return Vector3.zero;
        else return start.position;
    }
    public Vector3 GetCoordsEnd()
    {
        if (end == null) return Vector3.zero;
        else return end.position;
    }
    public Vector3 GetCoordsLStart()
    {
        if (start == null) return Vector3.zero;
        else return start.localPosition;
    }
    public Vector3 GetCoordsLEnd()
    {
        if (end == null) return Vector3.zero;
        else return end.localPosition;
    }
}
