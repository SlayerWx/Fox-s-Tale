using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    [SerializeField] string loadSceneName;
    public void LoadScene()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(loadSceneName);
        /*while (gameLevel.progress < 1)
        {*/
            yield return new WaitForEndOfFrame();
        /*}*/
    }
}
