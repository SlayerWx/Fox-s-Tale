using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public delegate void MyCollision(bool inn, PlayerMove.Direction dir);
    public static event MyCollision MyCollisionDetection;
    public PlayerMove.Direction myPos;
    private void OnTriggerEnter2D(Collider2D col)
    {
        MyCollisionDetection?.Invoke(true,myPos);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        MyCollisionDetection?.Invoke(false, myPos);
    }
}
