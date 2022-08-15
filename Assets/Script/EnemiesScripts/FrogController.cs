using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float hareketHizi;

    public Transform leftTarget, rightTarget;

    bool rightSide;

    Rigidbody2D rb;

    public SpriteRenderer sr;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;

        rightSide = true;
    }

    private void Update()
    {
        if (rightSide)
        {
            rb.velocity = new Vector2(hareketHizi, rb.velocity.y);

            sr.flipX = true;

            if(transform.position.x> rightTarget.position.x)
            {
                rightSide = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-hareketHizi, rb.velocity.y);

            sr.flipX = false;

            if (transform.position.x < leftTarget.position.x)
            {
                rightSide = true;
            }
        }
    }
}
