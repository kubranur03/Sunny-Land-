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

    public float hareketsuresi, beklemesuresi;

    float hareketsayaci, beklemesayaci;

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

        hareketsayaci = hareketsuresi;
    }

    private void Update()
    {

        if (hareketsayaci > 0)
        {
            hareketsayaci -= Time.deltaTime;

            if (rightSide)
            {
                rb.velocity = new Vector2(hareketHizi, rb.velocity.y);

                sr.flipX = true;

                if (transform.position.x > rightTarget.position.x)
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

            if (hareketsayaci <= 0) ;
            {
                beklemesayaci = Random.Range(beklemesuresi * 0.7f, beklemesuresi * 1.2f); ;

            }
            anim.SetBool("hareketediyor", true);
        }

        else if (beklemesayaci > 0)
        {
            beklemesayaci -= Time.deltaTime;
            rb.velocity = new Vector2(0, rb.velocity.y);

            if (beklemesayaci <= 0)
            {
                hareketsayaci = Random.Range(hareketsuresi * 0.7f, hareketsuresi * 1.2f); ;
            }
            anim.SetBool("hareketediyor", false);
        }
        }



    }

