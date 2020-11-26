using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PippeSound : MonoBehaviour
{
    public static bool isPlaying;
    [SerializeField] SpriteRenderer myRender;
    [SerializeField] float soundLenght = 4.0f;
    void Start()
    {
        isPlaying = false;
    }
    void FixedUpdate()
    {
        if (myRender.isVisible && !isPlaying)
        {
            AkSoundEngine.PostEvent("desague", transform.gameObject);
            isPlaying = true;
            StartCoroutine(Reset());
        }
    }
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(soundLenght);
        isPlaying = false;
    }
}
