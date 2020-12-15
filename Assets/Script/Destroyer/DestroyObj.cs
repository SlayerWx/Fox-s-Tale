using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    [SerializeField] PlayerMove player = null;
    GoInDirection myGoInDir;
    bool soundDeadMark;
    private void Start()
    {
        myGoInDir = GetComponent<GoInDirection>();
        soundDeadMark = false;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject.GetComponent<Transform>().gameObject);
            myGoInDir.DoWait();
        }
        else
        {
            player.SetAlive(false);
            if(!soundDeadMark) AkSoundEngine.PostEvent("deadByShadow",transform.gameObject);
            soundDeadMark = true;
        }
    }
}
