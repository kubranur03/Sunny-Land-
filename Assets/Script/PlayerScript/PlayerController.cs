using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float MovementSpeed;

    [SerializeField]
    private float JumpingPower;

    private bool IsItOnTheGround;
    [SerializeField] private Transform GroundControllPoint;
    [SerializeField] private LayerMask GroundLayer;
    private bool CanJumpTwice;


    [SerializeField] private float KickBackTime, KickBackStrength;
    private float KickBackCounter;
    private bool canChangeDirection;

    PlayerHealtBehaviour playerHealtBehaviour;

    Rigidbody2D rigidBody2D;

    Animator animator;

    public bool shouldMove;


   [SerializeField] private float JumpJumpPower;

    private void Awake()
    {
        playerHealtBehaviour = Object.FindObjectOfType<PlayerHealtBehaviour>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    private void Start()
    {
        shouldMove = true;
        
    }

    private void Update()
    {
        if (playerHealtBehaviour.gameOver)
        {
            return;
        }
        if(shouldMove)
        {
            if (KickBackCounter <= 0)
            {

                Move();
                Jump();
                ChangeDirection();
            }
            else
            {
                KickBackCounter -= Time.deltaTime;

                if (canChangeDirection)
                {
                    rigidBody2D.velocity = new Vector2(-KickBackStrength, rigidBody2D.velocity.y);
                }
                else
                {
                    rigidBody2D.velocity = new Vector2(KickBackStrength, rigidBody2D.velocity.y);
                }
            }



            animator.SetFloat("MovementSpeed", Mathf.Abs(rigidBody2D.velocity.x));
            animator.SetBool("IsItOnTheGround", IsItOnTheGround);
        }
        else
        {
            rigidBody2D.velocity = Vector2.zero;
            animator.SetFloat("MovementSpeed", Mathf.Abs(rigidBody2D.velocity.x));
        }

    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float hiz = h * MovementSpeed;

        rigidBody2D.velocity = new Vector2(hiz, rigidBody2D.velocity.y);

    }

    void Jump()
    {
        IsItOnTheGround = Physics2D.OverlapCircle(GroundControllPoint.position, .2f, GroundLayer);
        
        if(IsItOnTheGround)
        {
            CanJumpTwice = true;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(IsItOnTheGround)
            {
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, JumpingPower);

                AudioManager.instance.MakeASoundEffect(3);

            }
            else
            {
                if (CanJumpTwice)
                {
                    rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, JumpingPower);
                    CanJumpTwice = false;
                    AudioManager.instance.MakeASoundEffect(3);
                }
                

            }


        }
        

    }

    void ChangeDirection()
    {
        Vector2 TemporaryScale = transform.localScale;

        if(rigidBody2D.velocity.x>0)
        {
            canChangeDirection = true;
            TemporaryScale.x = 1f;
        }else if(rigidBody2D.velocity.x<0)
        {
            canChangeDirection = false;
            TemporaryScale.x = -1f;
        }

        transform.localScale = TemporaryScale;    
    }

    public void KickBack()
    {
        KickBackCounter = KickBackTime;
        rigidBody2D.velocity = new Vector2(0, rigidBody2D.velocity.y);

        animator.SetTrigger("damage");

    }

    public void JumpJump()
    {
        rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, JumpJumpPower);
        AudioManager.instance.MakeASoundEffect(3);
    }


}

