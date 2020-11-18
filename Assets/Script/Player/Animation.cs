using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Animation : MonoBehaviour
{
    [SerializeField] float timeXFrame = 0.0f;
    [SerializeField] SpriteRenderer mySprite;
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
    [SerializeField] Side[] animations;
    public enum State
    {
        Idle,Walk,Dash
    };
    private State state;
    public enum Direction
    {
        Left,Right,Up,Down
    };
    private Direction direction;
    void OnEnable()
    {
        PlayerMove.PlayerAnimationRequest += AnimRequest;
        index = 0;
    }
    void OnDisable()
    {
        PlayerMove.PlayerAnimationRequest -= AnimRequest;
    }
    void AnimRequest(State myState,Direction myDir)
    {
        state = myState;
        direction = myDir;
        index = 0;
    }
    IEnumerator Animator()
    {
        for (; index < animations[(int)state].side[(int)direction].animation.Length; index++)
        {
            mySprite.sprite = animations[(int)state].side[(int)direction].animation[index];
            yield return new WaitForSeconds(timeXFrame);
            if (index >= animations[(int)state].side[(int)direction].animation.Length) index = 0;
        }
    }
}