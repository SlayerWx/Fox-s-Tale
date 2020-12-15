using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GifLoop : MonoBehaviour
{
    [SerializeField] SpriteRenderer mySprite = null;
    [SerializeField] float timeXFrame = 0.0f;
    [SerializeField] Sprite[] steps = null;
    const int zero = 0;
    [SerializeField] bool isLoop = true;
    bool whileControl;
    void OnEnable()
    {
        if (isLoop)
        {
            StartCoroutine(Loop());
        };
        whileControl = true;
    }

    IEnumerator Loop()
    {
        short i = zero;
        whileControl = true;
        while (whileControl && zero != steps.Length && mySprite != null)
        {
            if (!(i < steps.Length) && isLoop) i = zero;
            if(mySprite != null)mySprite.sprite = steps[i];
            while ((StopTime.GetTimeStatus()) && gameObject.transform.tag !="Player")
            {
                yield return null;
            }
            yield return new WaitForSeconds(timeXFrame);
            i++;
            if (!isLoop && i >= steps.Length) whileControl = false;
        }
    }
    public void StartAnim()
    {
        StartCoroutine(Loop());
    }
}
