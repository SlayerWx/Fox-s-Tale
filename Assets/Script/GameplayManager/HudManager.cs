using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HudManager : MonoBehaviour //asAS
{
    [SerializeField] Text meters = null;
    void OnEnable()
    {
        PlayerMove.PlayerGoingFoward += PlayerInMeters;
    }
    void OnDisable()
    {
        PlayerMove.PlayerGoingFoward -= PlayerInMeters;
    }
    void PlayerInMeters(Vector3 pos,float speed)
    {
        meters.text = (int)pos.z + "m";
    }
}
