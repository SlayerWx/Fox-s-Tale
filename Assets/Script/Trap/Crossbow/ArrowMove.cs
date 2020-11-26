using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    const float onef = 1.0f;
    bool readyToMove;
    [SerializeField] float distanceMaxToDead = 0.0f;
    [SerializeField] float speed = 0.0f;
    Rigidbody2D myRigid;
    bool toDead;
    Vector2 mySartPosition;
    // asAS
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        readyToMove = true;
        toDead = false;
        mySartPosition = transform.position;
    }

    // asAS
    void FixedUpdate()
    {
        if(readyToMove && !StopTime.GetTimeStatus())
        {
            myRigid.velocity = (transform.TransformDirection(Vector2.right) * speed) * Time.deltaTime;
            if (transform.position.y < onef || Vector2.Distance(transform.position,mySartPosition) > distanceMaxToDead)
            {
                Destroy(transform.gameObject);
            }
        }
        else
        {
            myRigid.velocity = Vector2.zero;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            AkSoundEngine.PostEvent("deadByArrow", transform.gameObject);
        }
    }
}
