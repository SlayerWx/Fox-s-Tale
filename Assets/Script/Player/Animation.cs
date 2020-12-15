using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Animation : MonoBehaviour
{
    [SerializeField] float timeXFrame = 0.0f;
    [SerializeField] SpriteRenderer mySprite = null;
    int index = 0;
    #region StructToInspector
    [System.Serializable]
    public struct MyAnimation
    {
#if UNITY_EDITOR
        public readonly string name;
#endif
        public Sprite[] animation;
    };
    [System.Serializable]
    public struct Side
    {
#if UNITY_EDITOR
        public readonly string name;
#endif
        public MyAnimation[] side;
    };
    #endregion
    [SerializeField] Side[] animations = null;
    public enum State
    {
        Idle,Walk,Dash,Dead
    };
    private State state;
    public enum Direction
    {
        Left,Right,Up,Down
    };
    private Direction direction;
    void OnEnable()
    {
        PlayerMove.PlayerAnimationRequestState += AnimRequestState;
        PlayerMove.PlayerAnimationRequestDir += AnimRequestDir;
        AnimRequestDir(Direction.Down);
        AnimRequestState(State.Idle);
        StartCoroutine(Animator());
        index = 0;
    }
    void OnDisable()
    {
        PlayerMove.PlayerAnimationRequestState -= AnimRequestState;
        PlayerMove.PlayerAnimationRequestDir -= AnimRequestDir;
    }
    void AnimRequestState(State myState)
    {
        if (state != myState)
        {
            index = 0;
            state = myState;
        }
    }
    void AnimRequestDir(Direction myDir)
    {
        if (direction != myDir)
        {
            index = 0;
            direction = myDir;
        }
    }
    IEnumerator Animator()
    {
        while (index < animations[(int)state].side[(int)direction].animation.Length)
        {
            mySprite.sprite = animations[(int)state].side[(int)direction].animation[index];
            yield return new WaitForSeconds(timeXFrame);
            index++;
            if (index >= animations[(int)state].side[(int)direction].animation.Length && state != State.Dead) index = 0;
        }
    }
}