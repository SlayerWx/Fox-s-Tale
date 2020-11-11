using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Sprite[] mySpriteDash = null;
    [SerializeField] Image actualDashImage = null;
    int stepDash = 0;
    const int zero = 0;
    void OnEnable()
    {
        PlayerMove.DashStateInfo += ChangeDashButtonSprite;
        stepDash = zero;
    }
    void OnDisable()
    {
        PlayerMove.DashStateInfo -= ChangeDashButtonSprite;
    }
    void ChangeDashButtonSprite()
    {
        stepDash++;
        if (stepDash >= mySpriteDash.Length) stepDash = zero;
        actualDashImage.sprite = mySpriteDash[stepDash];
    }
}
