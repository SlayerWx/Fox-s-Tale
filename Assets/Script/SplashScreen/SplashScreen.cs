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
        //AkSoundEngine.SetRTPCValue("sfxVolume", 5.0f);
        //AkSoundEngine.SetRTPCValue("musicVolume", 0.0f);
        AkSoundEngine.PostEvent("gameStart", transform.gameObject);
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(nextScene);
    }
}
