using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour //asAS
{
    [SerializeField] Transform myCm;
    private bool cmMoving = false;
    Vector3 newPos = new Vector3();
    float speed = 0;
    float timer = 0;
    const float timerMax = 1.0f;
    const float zerof = 0.0f;
    Vector3 startPos = new Vector3();
    bool playerInPosition = false;
    void OnEnable()
    {
        PlayerMove.PlayerGoingFoward +=ResetCamPosition;
        playerInPosition = false;
    }
    void OnDisable()
    {
        PlayerMove.PlayerGoingFoward -=ResetCamPosition;
    }
    void ResetCamPosition(Vector2 NewPos,float Speed)
    {
        if (playerInPosition)
        {
            startPos = myCm.position;
            newPos = new Vector3(NewPos.x, NewPos.y, myCm.position.z);
            speed = Speed;
            if (cmMoving)
            {
                StopCoroutine(MovingCm());
            }
            StartCoroutine(MovingCm());
        }
        else if(NewPos.y >= myCm.position.y)
        {
            playerInPosition = true;
        }
    }
    IEnumerator MovingCm()
    {
        cmMoving = true;
        timer = zerof;
        while (timer < timerMax)
        {
           myCm.position = Vector3.Lerp(startPos, newPos, timer);
            timer += Time.deltaTime * speed;
            yield return null;
        }
        cmMoving = false;
    }
}
