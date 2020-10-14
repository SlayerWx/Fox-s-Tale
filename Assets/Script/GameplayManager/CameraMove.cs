using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour //asAS
{
    [SerializeField] Transform myCm = null;
    [SerializeField] Transform Player = null;
    [SerializeField] Transform destroyer = null;
    const float zerofOne = 0.1f;
    float myCmZ = 0;
    float mydestroyerZ = 0;
    float mydestroyery = 0;
    void OnEnable()
    {
        myCmZ = myCm.position.z;
        mydestroyerZ = destroyer.position.z;
    }
    void FixedUpdate()
    {
        myCm.position = Vector2.Lerp(myCm.position,Player.position, zerofOne);
        myCm.position = new Vector3(myCm.position.x,myCm.position.y,myCmZ);
        mydestroyery = destroyer.position.y;
        destroyer.position = Vector2.Lerp(destroyer.position, myCm.position, zerofOne);

        destroyer.position = new Vector3(destroyer.position.x, mydestroyery, mydestroyerZ);
    }
}
