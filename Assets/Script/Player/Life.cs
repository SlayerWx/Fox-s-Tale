using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    PlayerMove move;
    float deadTimeScale = 0.0f;
    void Start()
    {
        move = GetComponent<PlayerMove>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Trap")
        {
            move.SetAlive(false);
            Time.timeScale = deadTimeScale;
        }
    }

}
