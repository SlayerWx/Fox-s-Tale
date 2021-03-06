﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] animShot = null;
    [SerializeField] private Sprite[] animReload = null;
    SpriteRenderer myRender;
    GameObject arrow = null;
    ArrowMove moveArrow = null;
    [SerializeField] GameObject prefArrow = null;
    [SerializeField] float timeXFrame = 0.0f;
    [SerializeField] float interval = 0.0f;
    [SerializeField] Transform spawn = null;
    bool isOnAnim;
    [SerializeField] bool on = true; 
    // asAS
    void Start()
    {
        myRender = GetComponentInChildren<SpriteRenderer>();
        isOnAnim = false;
    }

    // asAS
    void Update()
    {
        ShotAnim();
    }
    void ShotAnim()
    {
        if (!isOnAnim && on)
        {
            if (null != myRender)
            {
                StartCoroutine(FrameSprite());
            }
    }
}
    void SummonArrow()
    {
        arrow = Instantiate(prefArrow, transform.position, transform.rotation, transform);
        arrow.transform.position = spawn.position;
        moveArrow = arrow.GetComponent<ArrowMove>();
    }
    IEnumerator FrameSprite()
    {
        if (null != myRender)
        {
            StopCoroutine(FrameSprite());
        }
        isOnAnim = true;
        for (int i = 0; i < animShot.Length && myRender; i++)
        {
                myRender.sprite = animShot[i];
            while ((StopTime.GetTimeStatus()))
            {
                yield return null;
            }
            yield return new WaitForSeconds(timeXFrame);
        }
        SummonArrow();

        if (myRender.isVisible)
        {
            AkSoundEngine.PostEvent("arrowShot", transform.gameObject);
        }
        for (int i = 0; i < animReload.Length && myRender;i++)
        {
            myRender.sprite = animReload[i];
            while ((StopTime.GetTimeStatus()))
            {
                yield return null;
            }
            yield return new WaitForSeconds(timeXFrame);
            
        }
        while ((StopTime.GetTimeStatus()))
        {
            yield return null;
        }
        yield return new WaitForSeconds(interval);

        isOnAnim = false;
    }
}
