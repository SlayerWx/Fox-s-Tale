using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInDirection : MonoBehaviour
{
    [SerializeField] Vector2 direction = new Vector2();
    [SerializeField] float speed = 0;
    [SerializeField] SpriteRenderer myRender = null;
    Rigidbody2D myRigid;
    [SerializeField] float timeToWaitAndContinous = 1.5f;
    bool waiting = false;
    bool inVisible;
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        inVisible = false;
        waiting = false;
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if (!StopTime.GetTimeStatus() && waiting)
        {
            myRigid.velocity = direction.normalized * speed * Time.deltaTime;
        }
        else
        {
            myRigid.velocity = Vector2.zero;
        }
        if(myRender.isVisible && !inVisible)
        {
            AkSoundEngine.PostEvent("shadow",transform.gameObject);
            inVisible = true;
        }
        else if (inVisible)
        {
            AkSoundEngine.PostEvent("shadow", transform.gameObject);
            inVisible = false;
        }
    }
    public void DoWait()
    {
        StartCoroutine(WaitASecond());
    }
    IEnumerator WaitASecond()
    {
        waiting = true;
        yield return new WaitForSeconds(timeToWaitAndContinous);
        waiting = false;
    }

}
