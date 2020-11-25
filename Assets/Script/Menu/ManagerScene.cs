using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{
    [SerializeField] string sceneName = null;
    public void ChangeScene()
    {

        AkSoundEngine.PostEvent("mouseClick", transform.gameObject);
        SceneManager.LoadScene(sceneName);
    }
}
