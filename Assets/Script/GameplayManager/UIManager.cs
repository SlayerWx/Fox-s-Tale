using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Sprite[] mySprite = null;
    [SerializeField] Image actualImage = null;
    const int one = 1;
    const int zero = 0;
    void OnEnable()
    {
        PlayerMove.DashStateInfo += ChangeDashButtonSprite;
    }
    void OnDisable()
    {
        PlayerMove.DashStateInfo -= ChangeDashButtonSprite;
    }
    void ChangeDashButtonSprite()
    {
        if(mySprite[0] == actualImage.sprite)
        {
            actualImage.sprite = mySprite[1];
        }
        else
        {
            actualImage.sprite = mySprite[0];
        }
    }
}
