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
    const float two = 2.0f;
    float modifDistanceToDash = 1.0f;
    [SerializeField] float speed = 0.0f;
    Vector2 startPosition;
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
        direction = Vector2.zero;
        startPosition = Vector2.zero;
        timer = 0.0f;
        moving = false;
        needWait = false;
        myRigid = GetComponent<Rigidbody2D>();
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
            direction = Vector2.zero;
            direction.x = Input.GetAxisRaw("Horizontal");
            if(direction.x == zeroF) direction.y = Input.GetAxisRaw("Vertical");
            if (direction.x < zeroF) myRender.sprite = left;
            if (direction.x > zeroF) myRender.sprite = right;
            if (direction.y > zeroF) myRender.sprite = up;
            if (direction.y < zeroF) myRender.sprite = down;
            if (dashReady)
            {
                modifDistanceToDash = two;
                canDash = false;
            }
        }
        if (direction != Vector2.zero && !moving && alive)
        {
            moving = true;
            startPosition = myRigid.position;
        }
       
    }
    void Move()
    {
        if(moving && !needWait && alive)//asAS
        {
            Vector2 ux = new Vector2((modifDistanceToDash * distance.x) * direction.x,
                                      (modifDistanceToDash * distance.y) * direction.y);
            ux = Vector2.Lerp(startPosition, startPosition + ux, timer);
            myRigid.MovePosition(ux);
            timer += Time.deltaTime * speed;
            if (timer >= one)
            {
                timer = zeroF;
                needWait = true;
                ux = new Vector2((modifDistanceToDash * distance.x) * direction.x,
                                 (modifDistanceToDash * distance.y) * direction.y);
                ux = Vector2.Lerp(startPosition, startPosition + ux, one);
                myRigid.MovePosition(ux);
                if (!canDash)
                {
                    modifDistanceToDash = one;
                }
                dashReady = false;
                PlayerGoingFoward?.Invoke(transform.position, speed);
                StartCoroutine(waitToNextMove());
                if(!canDash && !inCoolDownDash) StartCoroutine(waitingToDashAgain());
            }
        } 
    }
    void DropBodyCheck()
    {
        /*if(transform.position.z < zeroF)
        {
            alive = false;
        }*/
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
