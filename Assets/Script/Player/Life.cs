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
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Skewers")
        {
            move.SetAlive(false);
        }
    }

}
