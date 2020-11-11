using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWisp : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    [SerializeField] float Interval;
    void OnEnable()
    {
        StartCoroutine(SpawnWispTimer());
    }

    IEnumerator SpawnWispTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(Interval);
            Instantiate(Prefab, transform.position, Quaternion.identity, transform);
        }
    }
}
