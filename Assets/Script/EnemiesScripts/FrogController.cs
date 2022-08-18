using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float MovementSpeed;

    public Transform leftTarget, rightTarget;

    bool rightSide;

    Rigidbody2D rb;

    public SpriteRenderer sr;

    public float MovementTime, StandbyTime;

    float MovementCounter, StandbyCounter;

    Animator anim;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;

        rightSide = true;

        MovementCounter = MovementTime;
    }

    private void Update()
    {

        if (MovementCounter > 0)
        {
            MovementCounter -= Time.deltaTime;

            if (rightSide)
            {
                rb.velocity = new Vector2(MovementSpeed, rb.velocity.y);

                sr.flipX = true;

                if (transform.position.x > rightTarget.position.x)
                {
                    rightSide = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-MovementSpeed, rb.velocity.y);

                sr.flipX = false;

                if (transform.position.x < leftTarget.position.x)
                {
                    rightSide = true;
                }
            }

            if (MovementCounter <= 0) 
            {
                StandbyCounter = Random.Range(StandbyTime * 0.7f, StandbyTime * 1.2f); ;

            }
            anim.SetBool("ItIsMoving", true);
        }

        else if (StandbyCounter > 0)
        {
            StandbyCounter -= Time.deltaTime;
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (StandbyCounter <= 0)
            {
                MovementCounter = Random.Range(MovementTime * 0.7f, MovementTime * 1.2f); ;
            }
            anim.SetBool("ItIsMoving", false);
        }
        }



    }

