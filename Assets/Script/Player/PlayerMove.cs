using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D myRigid;
    const float zeroF = 0.0f;
    [SerializeField] Vector2 distance = new Vector2();
    Vector2 direction;
    bool moving;
    float timer;
    const float one = 1.0f;
    [SerializeField] float speed = 0.0f;
    Vector2 startPosition;
    [SerializeField] float timeToNextMove = 0.0f;
    bool needWait = false;
    public delegate void GoingFoward(Vector2 Position, float Speed);
    public static event GoingFoward PlayerGoingFoward;
    void Start()//asAS
    {
        direction = Vector2.zero;
        startPosition = Vector2.zero;
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
            if(direction.x == zeroF) direction.y = Input.GetAxisRaw("Vertical");
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
                PlayerGoingFoward?.Invoke(transform.position, speed);
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
