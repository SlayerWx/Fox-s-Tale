using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteriorationFloor : MonoBehaviour
{
    // asAS
    [SerializeField] float time = 0;
    [SerializeField] Sprite[] mySprite = null;
    [SerializeField] SpriteRenderer myRender = null;
    [SerializeField] PlayerMove plyer = null;
    bool deteriorationOn;
    bool playerInside;
    void Start()
    {
        playerInside = false;
        myRender.sprite = mySprite[0];
        gameObject.tag = "Untagged";
        deteriorationOn = false;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && gameObject.tag != "Trap" && !deteriorationOn)
        {
            deteriorationOn = true;
            StartCoroutine(deterioration());
        }
        if (col.gameObject.tag == "Player")
        {
            playerInside = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerInside = false;
        }
    }
    IEnumerator deterioration()
    {
        for (int i = 1;i < mySprite.Length; i++)
        {
            yield return new WaitForSeconds(time);
            myRender.sprite = mySprite[i];
        }
        gameObject.tag = "Trap";
        if (playerInside)
        {
            plyer.SetAlive(false);
        }
    }
}
