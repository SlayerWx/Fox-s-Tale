using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    bool readyToMove;
    [SerializeField] float timerLife = 0.0f;
    [SerializeField] float speed = 0.0f;
    Rigidbody2D myRigid;
    bool toDead;
    // asAS
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        readyToMove = false;
        toDead = false;
    }

    // asAS
    void FixedUpdate()
    {
        if(readyToMove)
        {
            myRigid.velocity = (transform.TransformDirection(Vector2.right) * speed) * Time.deltaTime;
        }
    }
    public void Ready()
    {
        readyToMove = true;
        if(!toDead)
        {
            toDead = true;
            Destroy(transform.gameObject, timerLife);
        }
    }
}
