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
        }
        meters.text = maxMeters + "m";
        deadMeters.text = meters.text;
    }
    
}
