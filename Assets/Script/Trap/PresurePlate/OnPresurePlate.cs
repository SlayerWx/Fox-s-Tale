using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPresurePlate : MonoBehaviour
{
    [SerializeField] GifLoop myGif;
    [SerializeField] DoorActivator door;
    bool pressed;
    void OnEnable()
    {
        pressed = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !StopTime.GetTimeStatus() && !pressed)
        {
            myGif.StartAnim();
            door.ButtonActivated();
            pressed = true;
        }
    }
    public bool GetPressed()
    {
        return pressed;
    }
}
