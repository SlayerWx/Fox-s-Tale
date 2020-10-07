using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAnimation : MonoBehaviour
{
    [SerializeField] Sprite[] mySprite = null;
    [SerializeField] float timer = 0.0f;
    SpriteRenderer myRender;
    int zero = 0;
    void Start()
    {
        mySprite[zero] = null;
        myRender = GetComponent<SpriteRenderer>();
        StartCoroutine(Test());
    }
    void Update()
    {
        
    }
    IEnumerator Test()
    {
        for (int i = 0; i < mySprite.Length; i++)
        {
            myRender.sprite = mySprite[i];
            yield return new WaitForSeconds(timer);
        }
    }
}
