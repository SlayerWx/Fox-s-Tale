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
    const float two = 2.0f;
    float modifDistanceToDash = 1.0f;
    [SerializeField] float speed = 0.0f;
    Vector3 startPosition;
    [SerializeField] float timeToNextMove = 0.0f;
    bool needWait = false;
    public delegate void GoingFoward(Vector3 Position, float Speed);
    public static event GoingFoward PlayerGoingFoward;
    bool alive;
    SpriteRenderer myRender;
    [SerializeField] Sprite left = null;
    [SerializeField] Sprite up = null;
    [SerializeField] Sprite right = null;
    [SerializeField] Sprite down = null;
    [SerializeField] string dashButton = null;
    [SerializeField] float waitToUseDashAgain = 0.0f;
    bool canDash;
    bool dashReady;
    bool inCoolDownDash;
    void Start()//asAS
    {
        direction = Vector3.zero;
        startPosition = Vector3.zero;
        timer = 0.0f;
        moving = false;
        needWait = false;
        myRigid = GetComponent<Rigidbody>();
        myRender = GetComponentInChildren<SpriteRenderer>();
        alive = true;
        dashReady = false;
        canDash = true;
        inCoolDownDash = false;
    }
    void Update()
    {
        InputMove();
    }
    void FixedUpdate()
    {
        DropBodyCheck();
        Move();
    }
    void InputMove()
    {
        if (Input.GetKeyDown(dashButton) && canDash)
        {
            dashReady = true;
        }
        if (!moving && alive)
        {
            direction = Vector3.zero;
            direction.x = Input.GetAxisRaw("Horizontal");
            if(direction.x == zeroF) direction.z = Input.GetAxisRaw("Vertical");
            if (direction.x < zeroF) myRender.sprite = left;
            if (direction.x > zeroF) myRender.sprite = right;
            if (direction.z > zeroF) myRender.sprite = up;
            if (direction.z < zeroF) myRender.sprite = down;
            if (dashReady)
            {
                modifDistanceToDash = two;
                canDash = false;
            }
        }
        if (direction != Vector3.zero && !moving && alive)
        {
            moving = true;
            startPosition = myRigid.position;
        }
       
    }
    void Move()
    {
        if(moving && !needWait && alive)//asAS
        {
            Vector3 ux = new Vector3((modifDistanceToDash * distance.x) * direction.x, distance.y * direction.y,
                                      (modifDistanceToDash * distance.z) * direction.z);
            ux = Vector3.Lerp(startPosition, startPosition + ux, timer);
            ux.y = transform.position.y;
            myRigid.MovePosition(ux);
            timer += Time.deltaTime * speed;
            if (timer >= one)
            {
                timer = zeroF;
                needWait = true;
                ux = new Vector3((modifDistanceToDash * distance.x) * direction.x, distance.y * direction.y,
                                 (modifDistanceToDash * distance.z) * direction.z);
                ux = Vector3.Lerp(startPosition, startPosition + ux, one);
                ux.y = transform.position.y;
                myRigid.MovePosition(ux);
                if(!canDash) modifDistanceToDash = one;
                dashReady = false;
                PlayerGoingFoward?.Invoke(transform.position, speed);
                StartCoroutine(waitToNextMove());
                if(!canDash && !inCoolDownDash) StartCoroutine(waitingToDashAgain());
            }
        } 
    }
    void DropBodyCheck()
    {
        if(transform.position.y < zeroF)
        {
            alive = false;
        }
    }
    IEnumerator waitToNextMove()
    {
        yield return new WaitForSeconds(timeToNextMove);
        needWait = false;
        moving = false;
    }
    IEnumerator waitingToDashAgain()
    {
        inCoolDownDash = true;
        yield return new WaitForSeconds(waitToUseDashAgain);
        canDash = true;
        inCoolDownDash = false;
        Debug.Log("Dash");
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
