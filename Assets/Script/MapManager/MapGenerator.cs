using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour // asAS
{
    [SerializeField] float preventDistansToViewed = 0.0f;
    [SerializeField] float betweenPrefab = 0.0f;
    [SerializeField] GameObject[] mapPrefab = null;
    [SerializeField] int maxMapGenerated = 0;
    List<GameObject> map = null;
    const int zero = 0;
    const int one = 1;
    [SerializeField] Vector3 correctRotation = new Vector3();
    void Start()
    {
        map = new List<GameObject>();
        for(int i = zero; i < maxMapGenerated;i++)
        {
            Vector3 aux = new Vector3(transform.position.x, transform.position.y , transform.position.z + (betweenPrefab * i));
            map.Add(Instantiate(mapPrefab[Random.Range(zero, mapPrefab.Length)],aux, Quaternion.identity,transform));
            map[i].transform.localRotation = Quaternion.Euler(correctRotation);
        }
    }
    void OnEnable()
    {
        PlayerMove.PlayerGoingFoward += GenerateMoreMap;
    }
    void OnDisable()
    {
        PlayerMove.PlayerGoingFoward -= GenerateMoreMap;
    }
    void GenerateMoreMap(Vector3 pos, float speed)
    {
        if(pos.z > map[map.Count-one].transform.localPosition.z - preventDistansToViewed)
        {
            Vector3 aux = map[map.Count-one].transform.position;
            aux.z += betweenPrefab;
            map.Add(Instantiate(mapPrefab[Random.Range(zero, mapPrefab.Length)], aux, Quaternion.identity, transform));
            map[map.Count-one].transform.localRotation = Quaternion.Euler(correctRotation);
        }
    }
}
