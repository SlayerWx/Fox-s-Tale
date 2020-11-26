using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    [SerializeField] PlayerMove player = null;
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject.GetComponent<Transform>().gameObject);
        }
        else
        {
            player.SetAlive(false);
            AkSoundEngine.PostEvent("deadByShadow",transform.gameObject);
        }
    }
}
