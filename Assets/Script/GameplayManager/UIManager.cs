using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Sprite[] mySpriteDash = null;
    [SerializeField] Image actualDashImage = null;
    [SerializeField] Sprite[] mySpriteTimeStop = null;
    [SerializeField] Image actualTimeStopImage = null;
    int stepDash = 0;
    int stepTimeStop = 0;
    const int zero = 0;
    void OnEnable()
    {
        PlayerMove.DashStateInfo += ChangeDashButtonSprite;
        PlayerMove.TimeStateFinish += TimeStopButtonSprite;
        stepDash = zero;
        stepTimeStop = zero;
    }
    void OnDisable()
    {
        PlayerMove.DashStateInfo -= ChangeDashButtonSprite;
        PlayerMove.TimeStateFinish -= TimeStopButtonSprite;
    }
    void ChangeDashButtonSprite()
    {
        stepDash++;
        if (stepDash >= mySpriteDash.Length) stepDash = zero;
        actualDashImage.sprite = mySpriteDash[stepDash];
    }
    void TimeStopButtonSprite()
    {
        stepTimeStop++;
        if (stepTimeStop >= mySpriteTimeStop.Length) stepTimeStop = zero;
        actualTimeStopImage.sprite = mySpriteTimeStop[stepTimeStop];
    }
}
