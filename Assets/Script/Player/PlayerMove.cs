using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,Walk,Dash
    };
    PlayerState myState;
    public enum Direction
    {
        Left,Right,Up,Down
    };
    Direction myDirection;
    struct DirectionsBool
    {
        public bool Left, Right, Up, Down;
    };
    DirectionsBool dirBool;
    Coroutine animCourroutine;
    Rigidbody2D myRigid;
    [SerializeField] Vector2 distance = new Vector2();
    Vector2 direction;
    bool moving;
    float timer;
    const int oneI = 1;
    const int zeroI = 0;
    const float zeroF = 0.0f;
    const float one = 1.0f;
    const float two = 2.0f;
    float modifDistanceToDash = 1.0f;
    [SerializeField] float speed = 0.0f;
    [SerializeField] float timePerFrame = 0.0f;
    Vector2 startPosition;
    [SerializeField] float timeToNextMove = 0.0f;
    [SerializeField] float stopTimeRefreshTime = 0.0f;
    [SerializeField] float timeInStopTime = 0.0f;
    bool needWait = false;
    public delegate void GoingFoward(Vector3 Position, float Speed);
    public static event GoingFoward PlayerGoingFoward;
    public delegate void PlayerDead();
    public static event PlayerDead PlayerIsDead;
    public delegate void PlayerPause();
    public static event PlayerPause PlayerPauseRequest;
    public delegate void DashState();
    public static event DashState DashStateInfo;
    public delegate void StopTimeState(bool w);
    public static event StopTimeState TimeState;
    public delegate void StopTimeStateFinish();
    public static event StopTimeStateFinish TimeStateFinish;
    bool alive;
    SpriteRenderer myRender;
    [SerializeField] Sprite[] left = null;
    [SerializeField] Sprite[] up = null;
    [SerializeField] Sprite[] right = null;
    [SerializeField] Sprite[] down = null;
    [SerializeField] string dashButton = null;
    [SerializeField] string pauseButton = null;
    [SerializeField] string StopTimeButton = null;
    bool canStopTime = true;
    [SerializeField] float waitToUseDashAgain = 0.0f;
    bool canDash;
    bool dashReady;
    bool inCoolDownDash;
    bool inFloor;
    bool isSlippingOut;
    bool refresingTimeStopTime = false;
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
        canStopTime = true;
        inFloor = true;
        myDirection = Direction.Down;
        animCourroutine = StartCoroutine(Anim(down));
        dirBool.Up = true;
        dirBool.Down = true;
        dirBool.Left = true;
        dirBool.Right = true;
        isSlippingOut = false;
        refresingTimeStopTime = false;
        myState = PlayerState.Idle;

    }
    void OnEnable()
    {
        CheckPlayerInFloor.InFloor += CheckFloor;
        CollisionDetector.MyCollisionDetection += CollisionDetect;
        ForcePlayerSlipper.PlayerSlipper += SlippingOut;
    }
    void OnDisable()
    {
        CheckPlayerInFloor.InFloor -= CheckFloor;
        CollisionDetector.MyCollisionDetection -= CollisionDetect;
        ForcePlayerSlipper.PlayerSlipper -= SlippingOut;
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
        if(Input.GetKeyDown(pauseButton) && alive)
        {
            PlayerPauseRequest?.Invoke();
        }
        if (Input.GetKeyDown(dashButton) && canDash && !moving)
        {
            dashReady = true; 
            DashStateInfo?.Invoke();
        }
        if(Input.GetKeyDown(StopTimeButton))
        {
            if (canStopTime && !refresingTimeStopTime)
            {
                canStopTime = false;
                TimeState?.Invoke(true);
                StartCoroutine(TimingInStopTime());
                TimeStateFinish?.Invoke();
            }
            else if(!refresingTimeStopTime)
            {
                TimeState?.Invoke(false);
                StartCoroutine(RefreshStopTime());
            }
        }
        if (!moving && alive && Time.deltaTime != zeroF)
        {
            if (!isSlippingOut)
            {
                direction = Vector2.zero;


                if(Input.GetKey(KeyCode.DownArrow) && dirBool.Down)
                {
                    direction.y = -one;
                }
                else if (Input.GetKey(KeyCode.UpArrow)&& dirBool.Up)
                {
                    direction.y = one;
                }
                else if (Input.GetKey(KeyCode.LeftArrow)&& dirBool.Left)
                {
                    direction.x = -one;
                }
                else if (Input.GetKey(KeyCode.RightArrow)&& dirBool.Right)
                {
                    direction.x = one;
                }
                AnimSelector(direction.x < zeroF,myState, Direction.Left, left);
                AnimSelector(direction.x > zeroF,myState, Direction.Right, right);
                AnimSelector(direction.y > zeroF,myState, Direction.Up, up);
                AnimSelector(direction.y < zeroF,myState, Direction.Down, down);
            }

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
        if(moving && !needWait && alive)
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
                    if (dashReady)
                    {
                        DashStateInfo?.Invoke();
                    }
                }
                dashReady = false;
                PlayerGoingFoward?.Invoke(transform.position, speed);
                StartCoroutine(waitToNextMove());
                if(!canDash && !inCoolDownDash) StartCoroutine(waitingToDashAgain());
            }
        } 
    }
    void AnimSelector(bool animationIF, PlayerState theState,Direction dir,Sprite[] dirSprite)
    {
        if(animationIF && theState == PlayerState.Idle && myDirection != dir && animCourroutine != null)
        {
            StopCoroutine(animCourroutine);
            myDirection = dir;
            animCourroutine = StartCoroutine(Anim(dirSprite));
        }
    }
    IEnumerator waitToNextMove()
    {
        yield return new WaitForSeconds(timeToNextMove);
        if (!inFloor)
        {
            alive = false;
            PlayerIsDead?.Invoke();
        }
        else
        {
            alive = true;
            needWait = false;
            moving = false;
        }
        
    }
    IEnumerator waitingToDashAgain()
    {
        inCoolDownDash = true;
        yield return new WaitForSeconds(waitToUseDashAgain);
        canDash = true;
        inCoolDownDash = false;
        DashStateInfo?.Invoke();
    }
    IEnumerator TimingInStopTime()
    {
        yield return new WaitForSeconds(timeInStopTime);
        TimeState?.Invoke(false);
        StartCoroutine(RefreshStopTime());
    }
    IEnumerator RefreshStopTime()
    {
        StopCoroutine(TimingInStopTime());
        refresingTimeStopTime = true;
        yield return new WaitForSeconds(stopTimeRefreshTime);
        canStopTime = true;
        TimeStateFinish?.Invoke();
        refresingTimeStopTime = false;
    }
    IEnumerator Anim(Sprite[] anim)
    {
        for (int i = zeroI; i < anim.Length; i++)
        {
            myRender.sprite = anim[i];
            yield return new WaitForSeconds(timePerFrame);
            if (anim.Length - one == i) i = zeroI;
        }
    }
    public void SetAlive(bool w)
    {
        if (!w)
        {
            PlayerIsDead?.Invoke();
        }
        alive = w;
    }
    public bool GetAlive()
    {
        return alive;
    }
    void CheckFloor(bool status)
    {
        inFloor = status;
    }
    public bool GetDashing()
    {
        return dashReady;
    }
    void CollisionDetect(bool inn, Direction dir)
    {
        if (Direction.Up == dir) dirBool.Up = !(inn);
        if (Direction.Down == dir) dirBool.Down = !(inn);
        if (Direction.Left == dir) dirBool.Left = !(inn);
        if (Direction.Right == dir) dirBool.Right = !(inn);
    }
    void SlippingOut(bool inn)
    {
        isSlippingOut = inn;
        if(isSlippingOut)dashReady = true;
    }
}
