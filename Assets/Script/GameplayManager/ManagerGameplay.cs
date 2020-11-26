using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerGameplay : MonoBehaviour
{
    // asAS
    const float zerof = 0.0f;
    const float onef = 1.0f;
    [SerializeField] float TimeToDeadMenu = 0;
    [SerializeField] GameObject deadLayer = null;
    [SerializeField] GameObject pauseLayer = null;
    [SerializeField] GameObject inGamePlayer = null;
    enum Layers
    {
        dead, pause, inGame
    }
    void OnEnable()
    {
        PlayerMove.PlayerIsDead += EndGame;
        PlayerMove.PlayerPauseRequest += pause;
        Time.timeScale = onef;
    }
    void OnDisable()
    {
        PlayerMove.PlayerIsDead -= EndGame;
        PlayerMove.PlayerPauseRequest -= pause; 
    }
    void EndGame()
    {
        StartCoroutine(InitDeadMenu());
    }
    IEnumerator InitDeadMenu()
    {

        yield return new WaitForSeconds(TimeToDeadMenu);
        Time.timeScale = zerof;
        activeLayer(Layers.dead);
    }
    void activeLayer(Layers option)
    {
        deadLayer.SetActive(option == Layers.dead);
        pauseLayer.SetActive(option == Layers.pause);
        inGamePlayer.SetActive(option == Layers.inGame);
        if(Layers.dead == option)
        {
            AkSoundEngine.PostEvent("deadMenu", transform.gameObject);
        }
    }
    void pause()
    {
        if (pauseLayer.activeSelf)
        {
            Time.timeScale = onef;
            activeLayer(Layers.inGame);
        }
        else
        {
            Time.timeScale = zerof;
            activeLayer(Layers.pause);
        }
    }
}
