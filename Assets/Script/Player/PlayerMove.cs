using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D myRigid;
    const float zeroF = 0.0f;
    Vector2 distance;
    Vector2 direction;
    bool moving;
    float timer;
    const float one = 1.0f;
    [SerializeField] float speed = 0.0f;
    Vector2 startPosition;
    [SerializeField] float timeToNextMove = 0.0f;
    bool needWait = false;
    void Start()//asAS
    {
        direction = Vector2.zero;
        startPosition = Vector2.zero;
        distance.x = 1.0f;
        distance.y = 1.0f;
        timer = 0.0f;
        moving = false;
        needWait = false;
        myRigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        InputMove();
    }
    void FixedUpdate()
    {
        Move();
    }
    void InputMove()
    {
        if (!moving)
        {
            direction = Vector2.zero;
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");
        }
        if (direction != Vector2.zero && !moving)
        {
            moving = true;
            startPosition = myRigid.position;
        }
       
    }
    void Move()
    {
        if(moving && !needWait)
        {
            myRigid.MovePosition(Vector2.Lerp(startPosition, startPosition + (distance * direction), timer));
            timer += Time.deltaTime * speed;
            if (timer >= one)
            {
                timer = zeroF;
                needWait = true;
                myRigid.MovePosition(Vector2.Lerp(startPosition, startPosition + (distance * direction), one));
                StartCoroutine(waitToNextMove());
            }
        }
    }
    IEnumerator waitToNextMove()
    {
        yield return new WaitForSeconds(timeToNextMove);
        needWait = false;
        moving = false;
    }
}
