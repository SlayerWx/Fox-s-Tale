using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDection : MonoBehaviour
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
        Time.timeScale = onef;
    }
    void OnDisable()
    {
        PlayerMove.PlayerIsDead -= EndGame;
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
    }
}
