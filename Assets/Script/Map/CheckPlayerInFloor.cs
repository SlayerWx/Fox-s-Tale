using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInFloor : MonoBehaviour//asAS
{
    public delegate void CPIF(bool status);
    public static event CPIF InFloor;
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        InFloor?.Invoke(true);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        InFloor?.Invoke(false);

    }
}
