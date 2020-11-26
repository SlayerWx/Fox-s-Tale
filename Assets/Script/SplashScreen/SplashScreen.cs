using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    // asAS
    [SerializeField] string nextScene = null;
    [SerializeField] float time = 0;
    void Start()
    {
        AkSoundEngine.PostEvent("gameStart", transform.gameObject);
        AkSoundEngine.SetRTPCValue("sfxVolume", 50.0f);
        AkSoundEngine.SetRTPCValue("musicVolume", 50.0f);
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(nextScene);
    }
}
