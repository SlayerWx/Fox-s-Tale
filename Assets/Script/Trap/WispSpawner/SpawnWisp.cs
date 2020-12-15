using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWisp : MonoBehaviour
{
    [SerializeField] GameObject Prefab = null;
    [SerializeField] float Interval = 0;
    public static int count = 0;
    const int countMax = 10;
    SpriteRenderer myRender;
    void OnEnable()
    {
        StartCoroutine(SpawnWispTimer());
        myRender = GetComponentInChildren<SpriteRenderer>();
    }

    IEnumerator SpawnWispTimer()
    {
        while (true)
        {
            while ((StopTime.GetTimeStatus()))
            {
                yield return null;
            }
            yield return new WaitForSeconds(Interval);
            while ((StopTime.GetTimeStatus()))
            {
                yield return null;
            }
            if (count < countMax)
            {
                Instantiate(Prefab, transform.position, Quaternion.identity, transform);
                if (myRender.isVisible)
                {
                    AkSoundEngine.PostEvent("spawnWisps", transform.gameObject);
                }
                count++;
            }
        }
    }
}
