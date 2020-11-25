using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] RectTransform[] layers = null;
    [SerializeField] float[] speed = null;
    [SerializeField] Vector2 direction;
    const int two = 2;
    const int lessTwo = -2;
    const float heightCorrectionLastPos = 1.5f;
    void FixedUpdate()
    {

        for (int i = 0; i < layers.Length; i++)
        {
            layers[i].anchoredPosition = new Vector2(layers[i].anchoredPosition.x + (speed[(int)(i / two)] * Time.deltaTime) * direction.normalized.x,
                layers[i].anchoredPosition.y + (speed[(int)(i / two)] * Time.deltaTime) * direction.normalized.y);
            if(layers[i].anchoredPosition.x - layers[i].rect.width/two  > layers[i].rect.width/two ||
                layers[i].anchoredPosition.y - layers[i].rect.height / two < -layers[i].rect.height * heightCorrectionLastPos)
            {
                layers[i].anchoredPosition = new Vector2(layers[i].anchoredPosition.x - (layers[i].rect.width * two) * direction.normalized.x,
                    layers[i].anchoredPosition.y - (layers[i].rect.height * two) * direction.normalized.y);
            }
        }
    }
}
