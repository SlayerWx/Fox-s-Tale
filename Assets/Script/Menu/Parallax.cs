using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] RectTransform[] layers = null;
    [SerializeField] float[] speed = null;
    const int two = 2;
    const int lessTwo = -2;
    void FixedUpdate()
    {

        for (int i = 0; i < layers.Length; i++)
        {
            layers[i].anchoredPosition = new Vector2(layers[i].anchoredPosition.x + (speed[(int)(i / two)] * Time.deltaTime),
                layers[i].anchoredPosition.y);
            if(layers[i].anchoredPosition.x - layers[i].rect.width/two  > layers[i].rect.width/two)
            {
                layers[i].anchoredPosition = new Vector2(layers[i].anchoredPosition.x - (layers[i].rect.width * two),layers[i].anchoredPosition.y);
            }
        }
    }
}
