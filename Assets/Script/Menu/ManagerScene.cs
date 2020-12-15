using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    [SerializeField] string sceneName = null;
    [SerializeField] GameObject loadLayer = null;
    public void ChangeScene()
    {
        AkSoundEngine.PostEvent("mouseClick", transform.gameObject);
        StartCoroutine(LoadAsync());
    }
    IEnumerator LoadAsync()
    {
        loadLayer.SetActive(true);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(sceneName);
        while (gameLevel.progress < 1) //next.. progressBar?
        {
        yield return new WaitForEndOfFrame();
        }
    }
}
