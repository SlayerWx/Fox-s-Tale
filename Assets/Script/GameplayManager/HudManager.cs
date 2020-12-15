using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudManager : MonoBehaviour //asAS
{
    [SerializeField] Text meters = null;
    [SerializeField] Text deadMeters = null;
    int zero = 0;
    int maxMeters = 0;
    void OnEnable()
    {
        PlayerMove.PlayerGoingFoward += PlayerInMeters;
        maxMeters = zero;
        AkSoundEngine.PostEvent("matchStart", transform.gameObject);
    }
    void OnDisable()
    {
        PlayerMove.PlayerGoingFoward -= PlayerInMeters;
    }
    void PlayerInMeters(Vector3 pos,float speed)
    {
        if(pos.y > maxMeters)
        {
            maxMeters = (int)pos.y;
            if (maxMeters == 70) AkSoundEngine.PostEvent("score70", transform.gameObject);
            if (maxMeters == 140) AkSoundEngine.PostEvent("score140", transform.gameObject);
            if (maxMeters == 200) AkSoundEngine.PostEvent("score200", transform.gameObject);
        }
        meters.text = maxMeters + "m";
        deadMeters.text = meters.text;
    }
    
}
