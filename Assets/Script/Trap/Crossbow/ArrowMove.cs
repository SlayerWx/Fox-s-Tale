using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    const float onef = 1.0f;
    bool readyToMove;
    [SerializeField] float timerLife = 0.0f;
    [SerializeField] float speed = 0.0f;
    Rigidbody2D myRigid;
    bool toDead;
    // asAS
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        readyToMove = true;
        toDead = false;
    }

    // asAS
    void FixedUpdate()
    {
        if(readyToMove && !StopTime.GetTimeStatus())
        {
            myRigid.velocity = (transform.TransformDirection(Vector2.right) * speed) * Time.deltaTime;
            if (transform.position.y < onef)
            {
                Destroy(transform.gameObject);
            }
        }
    }
    public void Ready()
    {
        readyToMove = true;
        if(!toDead)
        {
            toDead = true;
            if (null != gameObject)
            {
                Destroy(transform.gameObject, timerLife);
            }
        }
    }
}
