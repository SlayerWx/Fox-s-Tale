using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDestroyer : MonoBehaviour
{
    [SerializeField] GameObject destroyer = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            destroyer.SetActive(true);
    }
}
