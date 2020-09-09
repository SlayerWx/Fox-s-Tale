using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInDirection : MonoBehaviour
{
    [SerializeField] Vector3 direction = new Vector3();
    [SerializeField] float speed = 0;
    Rigidbody myRigid; 
    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
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
