using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
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
    public delegate void AnimationSystemState(Animation.State myState);
    public static event AnimationSystemState PlayerAnimationRequestState;
    public delegate void AnimationSystemDir(Animation.Direction myDir);
    public static event AnimationSystemDir PlayerAnimationRequestDir;
    bool alive;
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
        alive = true;
        dashReady = false;
        canDash = true;
        inCoolDownDash = false;
        canStopTime = true;
        inFloor = true;
        myDirection = Direction.Down;
        dirBool.Up = true;
        dirBool.Down = true;
        dirBool.Left = true;
        dirBool.Right = true;
        isSlippingOut = false;
        refresingTimeStopTime = false;
        PlayerAnimationRequestState?.Invoke(Animation.State.Idle);
        PlayerAnimationRequestDir?.Invoke(Animation.Direction.Down);

    }
    void OnEnable()
    {
        CheckPlayerInFloor.InFloor += CheckFloor;
        CollisionDetector.MyCollisionDetection += CollisionDetect;
        ForcePlayerSlipper.PlayerSlipper += SlippingOut;
        PlayerAnimationRequestState?.Invoke(Animation.State.Idle);
        PlayerAnimationRequestDir?.Invoke(Animation.Direction.Down);
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

                PlayerAnimationRequestState?.Invoke(Animation.State.Idle);

                if (Input.GetKey(KeyCode.DownArrow) && dirBool.Down)
                {
                    direction.y = -one;
                    PlayerAnimationRequestDir?.Invoke(Animation.Direction.Down);
                    PlayerAnimationRequestState?.Invoke(Animation.State.Walk);
                }
                else if (Input.GetKey(KeyCode.UpArrow)&& dirBool.Up)
                {
                    direction.y = one;
                    PlayerAnimationRequestDir?.Invoke(Animation.Direction.Up);
                    PlayerAnimationRequestState?.Invoke(Animation.State.Walk);
                }
                else if (Input.GetKey(KeyCode.LeftArrow)&& dirBool.Left)
                {
                    direction.x = -one;
                    PlayerAnimationRequestDir?.Invoke(Animation.Direction.Left);
                    PlayerAnimationRequestState?.Invoke(Animation.State.Walk);
                }
                else if (Input.GetKey(KeyCode.RightArrow)&& dirBool.Right)
                {
                    direction.x = one;
                    PlayerAnimationRequestDir?.Invoke(Animation.Direction.Right);
                    PlayerAnimationRequestState?.Invoke(Animation.State.Walk);
                }
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
            if(modifDistanceToDash == two)PlayerAnimationRequestState?.Invoke(Animation.State.Dash);
            ux = Vector2.Lerp(startPosition, startPosition + ux, timer);
            myRigid.MovePosition(ux);
            timer += Time.deltaTime * speed;
            if (canDash && !isSlippingOut)
            {
                AkSoundEngine.PostEvent("playFootstep", transform.gameObject);
            }
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
    IEnumerator waitToNextMove()
    {
        yield return new WaitForSeconds(timeToNextMove);
        if (!inFloor)
        {
            alive = false;
            AkSoundEngine.PostEvent("playFootstep", transform.gameObject);
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
