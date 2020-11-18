using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWisp : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    [SerializeField] float Interval;
    public static int count = 0;
    const int countMax = 10;
    void OnEnable()
    {
        StartCoroutine(SpawnWispTimer());
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
                count++;
            }
        }
    }
}
