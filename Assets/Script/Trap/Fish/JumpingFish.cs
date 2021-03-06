﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingFish : MonoBehaviour
{
    [System.Serializable]
    public struct SpriteBoxCollider
    {
        public Sprite mySprite;
        public Vector2 offset;
        public Vector2 size;
        public SpriteBoxCollider(Sprite mySprite, Vector2 offset, Vector2 size)
        { this.mySprite = mySprite; this.offset = offset; this.size = size; }
    }
    [SerializeField] SpriteRenderer mySprite = null;
    [SerializeField] BoxCollider2D myCollider = null;
    [SerializeField] float timeXFrame = 0.0f;
    [SerializeField] float coldown = 0.0f;
    [SerializeField] SpriteBoxCollider[] spriteAndColliderPoints = null;
    const int zero = 0;
    const int one = 1;
    void OnEnable()
    {
        mySprite.sprite = spriteAndColliderPoints[zero].mySprite;
        myCollider.offset = spriteAndColliderPoints[zero].offset;
        myCollider.size = spriteAndColliderPoints[zero].size;
        StartCoroutine(Jump());
    }
    IEnumerator Jump()
    {
        while (true && mySprite != null)
        {
            if (mySprite.isVisible)
            {
                for (short i = one; i < spriteAndColliderPoints.Length && mySprite != null; i++)
                {
                    if (i == one)
                    {

                        AkSoundEngine.PostEvent("fishJump", transform.gameObject);

                    }
                    mySprite.sprite = spriteAndColliderPoints[i].mySprite;
                    myCollider.offset = spriteAndColliderPoints[i].offset;
                    myCollider.size = spriteAndColliderPoints[i].size;
                    while ((StopTime.GetTimeStatus()))
                    {
                        yield return null;
                    }
                    yield return new WaitForSeconds(timeXFrame);
                }
                mySprite.sprite = spriteAndColliderPoints[zero].mySprite;
                myCollider.offset = spriteAndColliderPoints[zero].offset;
                myCollider.size = spriteAndColliderPoints[zero].size;
                while ((StopTime.GetTimeStatus()))
                {
                    yield return null;
                }
                yield return new WaitForSeconds(coldown);
            }
            else
            {
                yield return new WaitForSeconds(timeXFrame);
            }

        }
    }
}
