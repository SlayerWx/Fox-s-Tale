using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInDirection : MonoBehaviour
{
    [SerializeField] Vector2 direction = new Vector2();
    [SerializeField] float speed = 0;
    Rigidbody2D myRigid;
    [SerializeField] Sprite[] mySprite = null;
    [SerializeField] SpriteRenderer actualImage = null;
    [SerializeField] float time = 0;
    bool next = true;
    const int one = 1;
    const int zero = 0;
    void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        myRigid.velocity = direction.normalized * speed * Time.deltaTime;
        ChangeSprite();
    }

    void ChangeSprite()
    {
        if (next)
        {
            if (mySprite[zero] == actualImage.sprite)
            {
                actualImage.sprite = mySprite[one];
            }
            else
            {
                actualImage.sprite = mySprite[zero];
            }
            StartCoroutine(Timer());
        }
    }
    IEnumerator Timer()
    {
        next = false;
        yield return new WaitForSeconds(time);
        next = true;
    }
}
