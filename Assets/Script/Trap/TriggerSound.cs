using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    [SerializeField] string eventName;
    [SerializeField] string targetTag;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            AkSoundEngine.PostEvent(eventName, transform.gameObject);
        }
    }
}
