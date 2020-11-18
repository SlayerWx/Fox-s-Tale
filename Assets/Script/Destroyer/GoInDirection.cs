using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInDirection : MonoBehaviour
{
    [SerializeField] Vector2 direction = new Vector2();
    [SerializeField] float speed = 0;
    Rigidbody2D myRigid;
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (!StopTime.GetTimeStatus())
        {
            myRigid.velocity = direction.normalized * speed * Time.deltaTime;
        }
        else
        {
            myRigid.velocity = Vector2.zero;
        }
    }

}
