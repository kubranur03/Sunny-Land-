using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBehaviour : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    [SerializeField] private Transform leftTarget, rightTarget;

    private bool isRightSide;

    private Rigidbody2D rigidBody2D;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float movementTime, standbyTime;

    private float movementCounter, standbyCounter;

    private Animator animator;


    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        leftTarget.parent = null;
        rightTarget.parent = null;

        isRightSide = true;

        movementCounter = movementTime;
    }

    private void Update()
    {

        if (movementCounter > 0)
        {
            movementCounter -= Time.deltaTime;

            if (isRightSide)
            {
                rigidBody2D.velocity = new Vector2(movementSpeed, rigidBody2D.velocity.y);

                spriteRenderer.flipX = true;

                if (transform.position.x > rightTarget.position.x)
                {
                    isRightSide = false;
                }
            }
            else
            {
                rigidBody2D.velocity = new Vector2(-movementSpeed, rigidBody2D.velocity.y);

                spriteRenderer.flipX = false;

                if (transform.position.x < leftTarget.position.x)
                {
                    isRightSide = true;
                }
            }

            if (movementCounter <= 0) 
            {
                standbyCounter = Random.Range(standbyTime * 0.7f, standbyTime * 1.2f); ;

            }
            animator.SetBool("ItIsMoving", true);
        }

        else if (standbyCounter > 0)
        {
            standbyCounter -= Time.deltaTime;
            rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);

            if (standbyCounter <= 0)
            {
                movementCounter = Random.Range(movementTime * 0.7f, movementTime * 1.2f); ;
            }
            animator.SetBool("ItIsMoving", false);
        }
        }



    }

