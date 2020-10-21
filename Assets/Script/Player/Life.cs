using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    PlayerMove move;
    void Start()
    {
        move = GetComponent<PlayerMove>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Trap" && !move.GetDashing())
        {
            move.SetAlive(false);
            
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Trap" && !move.GetDashing())
        {
            move.SetAlive(false);

        }
    }

}
