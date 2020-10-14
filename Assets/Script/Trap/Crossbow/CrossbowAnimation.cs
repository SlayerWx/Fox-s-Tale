using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] anim = null;
    SpriteRenderer myRender;
    GameObject arrow = null;
    ArrowMove moveArrow = null;
    [SerializeField] GameObject prefArrow = null;
    [SerializeField] float correctionArrowPosY = 0.0f;
    [SerializeField] float timeXFrame = 0.0f;
    [SerializeField] float interval = 0.0f;
    [SerializeField] Vector3[] arrowPosAnim = null;
    bool isOnAnim;
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
        if (!isOnAnim)
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
        arrow.transform.position = new Vector3(arrow.transform.position.x,
                                            arrow.transform.position.y + correctionArrowPosY,
                                            arrow.transform.position.z);
        moveArrow = arrow.GetComponent<ArrowMove>();
    }
    IEnumerator FrameSprite()
    {
        if (null != myRender)
        {
            StopCoroutine(FrameSprite());
        }
        isOnAnim = true;
        SummonArrow();
        for (int i = 0; i < anim.Length && null != gameObject; i++)
        {
            
                myRender.sprite = anim[i];
            if (i < arrowPosAnim.Length && null != gameObject) arrow.transform.localPosition = arrowPosAnim[i];
            else if (null != gameObject) moveArrow.Ready();
            yield return new WaitForSeconds(timeXFrame);
            
        }

        yield return new WaitForSeconds(interval);
        isOnAnim = false;
    }
}
