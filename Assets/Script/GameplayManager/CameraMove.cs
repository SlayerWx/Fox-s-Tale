using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour //asAS
{
    [SerializeField] Transform myCm = null;
    [SerializeField] Transform Player = null;
    const float zerofOne = 0.1f;
    float myCmZ = 0;
    void OnEnable()
    {
        myCmZ = myCm.position.z;
    }
    void FixedUpdate()
    {
        myCm.position = Vector2.Lerp(myCm.position,Player.position, zerofOne);
        myCm.position = new Vector3(myCm.position.x,myCm.position.y,myCmZ);
    }
}
