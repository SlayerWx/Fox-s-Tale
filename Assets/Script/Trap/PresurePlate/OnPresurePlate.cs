using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPresurePlate : MonoBehaviour
{
    [SerializeField] GifLoop myGif;
    bool pressed;
    void OnEnable()
    {
        pressed = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            myGif.StartAnim();
            pressed = true;
        }
    }
    public bool GetPressed()
    {
        return pressed;
    }
}
