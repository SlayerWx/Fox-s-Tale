using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour // asAS
{
    [SerializeField] float preventDistansToViewed = 0.0f;
    [SerializeField] GameObject[] mapPrefab = null;
    [SerializeField] int maxMapGenerated = 0;
    List<GameObject> map = null;
    const int zero = 0;
    const int one = 1;
    GameObject lastInst = null;
    MapData lastData = null;
    float difX;
    float distanceToUnlockMoreMap = 90.0f;
    void Start()
    {
        lastInst = null;
        lastData = null;
        map = new List<GameObject>();
        difX = 0;
        for(int i = zero; i < maxMapGenerated;i++)
        {
            Vector3 aux = Vector3.zero;
            if (i == zero)
                aux = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            else
            {
                aux = new Vector3(transform.position.x, lastData.GetCoordsEnd().y, transform.position.z);
                difX = lastData.GetCoordsEnd().x;
            }
            lastInst = Instantiate(mapPrefab[Random.Range(zero, (mapPrefab.Length /2))], aux, Quaternion.identity, transform);
            lastData = lastInst.GetComponent<MapData>();
            if (i != zero)
            {
                difX -= lastData.GetCoordsStart().x;
                lastInst.transform.position = new Vector3(lastInst.transform.position.x + difX,
                    Mathf.Abs(lastInst.transform.position.y) + Mathf.Abs(lastData.GetCoordsLStart().y)
                    , transform.position.z);
            }
            else
            {
                lastInst.transform.position = new Vector3(lastInst.transform.position.x - lastData.GetCoordsLStart().x
                    , lastInst.transform.position.y - lastData.GetCoordsLStart().y, lastInst.transform.position.z);
            }
            
            map.Add(lastInst);

        }
    }
    void OnEnable()
    {
        PlayerMove.PlayerGoingFoward += GenerateMoreMap;
    }
    void OnDisable()
    {
        PlayerMove.PlayerGoingFoward -= GenerateMoreMap;
        map.Clear();
    }
    void GenerateMoreMap(Vector3 pos, float speed)
    {
        if(pos.y > map[map.Count-one].transform.localPosition.y - preventDistansToViewed)
        {
            Vector3 aux = new Vector3(transform.position.x, lastData.GetCoordsEnd().y, transform.position.z);
            difX = lastData.GetCoordsEnd().x;
            if(pos.y > distanceToUnlockMoreMap)
                lastInst = Instantiate(mapPrefab[Random.Range(zero, mapPrefab.Length)], aux, Quaternion.identity, transform);
            else
                lastInst = Instantiate(mapPrefab[Random.Range(zero, mapPrefab.Length/2)], aux, Quaternion.identity, transform);
            lastData = lastInst.GetComponent<MapData>();
            difX -= lastData.GetCoordsStart().x;
            lastInst.transform.position = new Vector3(lastInst.transform.position.x + difX,
                Mathf.Abs(lastInst.transform.position.y) + Mathf.Abs(lastData.GetCoordsLStart().y)
                , transform.position.z);
            map.Add(lastInst);

        }
    }
}
