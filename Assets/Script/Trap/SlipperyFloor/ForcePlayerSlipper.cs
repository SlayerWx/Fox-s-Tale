using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlayerSlipper : MonoBehaviour
{
    public delegate void Slipper(bool inn);
    public static event Slipper PlayerSlipper;
    [SerializeField] GifLoop myGif;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            myGif.StartAnim();
            PlayerSlipper?.Invoke(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerSlipper?.Invoke(false);
        }
    }
}
