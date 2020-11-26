using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLayer : MonoBehaviour
{
    public void ChangeThisLayer()
    {
        transform.gameObject.SetActive(!transform.gameObject.activeSelf);
    }
}
