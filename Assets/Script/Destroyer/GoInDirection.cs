using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInDirection : MonoBehaviour
{
    [SerializeField] Vector3 direction = new Vector3();
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
        myRigid.velocity = direction.normalized * speed * Time.deltaTime;
    }
}
