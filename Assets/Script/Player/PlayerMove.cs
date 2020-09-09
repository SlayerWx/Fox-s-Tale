using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody myRigid;
    const float zeroF = 0.0f;
    [SerializeField] Vector3 distance = new Vector3();
    Vector3 direction;
    bool moving;
    float timer;
    const float one = 1.0f;
    [SerializeField] float speed = 0.0f;
    Vector3 startPosition;
    [SerializeField] float timeToNextMove = 0.0f;
    bool needWait = false;
    public delegate void GoingFoward(Vector3 Position, float Speed);
    public static event GoingFoward PlayerGoingFoward;
    bool alive;
    void Start()//asAS
    {
        direction = Vector3.zero;
        startPosition = Vector3.zero;
        timer = 0.0f;
        moving = false;
        needWait = false;
        myRigid = GetComponent<Rigidbody>();
        alive = true;
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
            direction = Vector3.zero;
            direction.x = Input.GetAxisRaw("Horizontal");
            if(direction.x == zeroF) direction.z = Input.GetAxisRaw("Vertical");
        }
        if (direction != Vector3.zero && !moving)
        {
            moving = true;
            startPosition = myRigid.position;
        }
       
    }
    void Move()
    {
        if(moving && !needWait)//asAS
        {
            Vector3 ux = new Vector3(distance.x * direction.x, distance.y * direction.y, distance.z * direction.z);
            ux = Vector3.Lerp(startPosition, startPosition + ux, timer);
            ux.y = transform.position.y;
            myRigid.MovePosition(ux);
            timer += Time.deltaTime * speed;
            if (timer >= one)
            {
                timer = zeroF;
                needWait = true;
                ux = new Vector3(distance.x * direction.x, distance.y * direction.y, distance.z * direction.z);
                ux = Vector3.Lerp(startPosition, startPosition + ux, one);
                ux.y = transform.position.y;
                myRigid.MovePosition(ux);
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("!");
        if(collision.gameObject.tag == "Safe")
        {

        }
        if(collision.gameObject.tag == "NoSafe")
        {

        }
    }
    public void SetAlive(bool w)
    {
        alive = w;
    }
    public bool GetAlive()
    {
        return alive;
    }
}
