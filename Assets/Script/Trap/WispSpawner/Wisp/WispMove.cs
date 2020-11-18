using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispMove : MonoBehaviour
{
    [SerializeField] float intervalXMove = 0;
    Vector3 newPos;
    [SerializeField] float minDistance;
    [SerializeField] float stopDistance;
    [SerializeField] float mySpeed;
    Vector3 randomDir;
    Vector3 dir;
    const int zero = 0;
    const int one = 1;
    const int two = 2;
    void Start()
    {
        StartCoroutine(Move());  
    }
    void OnEnable()
    {
        newPos = Vector3.zero;
        randomDir = Vector3.zero;
        PlayerMove.PlayerGoingFoward += SetNewFollowPosition;
    }
    void OnDisable()
    {
        PlayerMove.PlayerGoingFoward -= SetNewFollowPosition;
        SpawnWisp.count--;
    }
    IEnumerator Move()
    {
        while(true)
        {
            yield return new WaitForSeconds(intervalXMove);
            if(newPos != Vector3.zero)
            {
                if(minDistance > Vector3.Distance(transform.position,newPos) && stopDistance < Vector3.Distance(transform.position, newPos))
                {
                    transform.position += dir.normalized * mySpeed * Time.deltaTime;
                }
                else
                {
                    randomDir = new Vector3(Random.Range(-one,two), Random.Range(-one, two), zero);
                    transform.position += randomDir * mySpeed * Time.deltaTime;
                }
            }
        }
    }
    void SetNewFollowPosition(Vector3 pos,float speed)
    {
        newPos = pos;
        dir = (transform.position - newPos) * -one;
    }
}
