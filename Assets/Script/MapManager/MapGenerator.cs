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
    void Start()
    {
        map = new List<GameObject>();
        for(int i = zero; i < maxMapGenerated;i++)
        {
            Vector3 aux = new Vector3(transform.position.x, transform.position.y + (betweenPrefab * i), transform.position.z);
            map.Add(Instantiate(mapPrefab[Random.Range(zero, mapPrefab.Length)],aux, Quaternion.identity,transform));
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
    void GenerateMoreMap(Vector2 pos, float speed)
    {
        if(pos.y > map[map.Count-one].transform.localPosition.y - preventDistansToViewed)
        {
            Vector3 aux = map[map.Count-one].transform.position;
            aux.y += betweenPrefab;
            map.Add(Instantiate(mapPrefab[Random.Range(zero, mapPrefab.Length)], aux, Quaternion.identity, transform));
        }
    }
}
