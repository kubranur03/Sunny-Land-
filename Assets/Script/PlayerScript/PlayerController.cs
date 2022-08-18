using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float MovementSpeed;

    [SerializeField]
    float JumpingPower;

    bool IsItOnTheGround;
    public Transform GroundControllPoint;
    public LayerMask GroundLayer;
    bool CanJumpTwice;


    public float KickBackTime, KickBackStrength;
    float KickBackCounter;
    bool direction;


    Rigidbody2D rb;

    Animator anim;

    public float JumpJumpPower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if(KickBackCounter<=0)
        {

            MoveFNC();
            JumpFNC();
            ChangeDirection();
        }
        else
        {
            KickBackCounter -= Time.deltaTime;

            if(direction)
            {
                rb.velocity = new Vector2(-KickBackStrength, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(KickBackStrength, rb.velocity.y);
            }
        }



        anim.SetFloat("MovementSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("IsItOnTheGround", IsItOnTheGround);

    }

    void MoveFNC()
    {
        float h = Input.GetAxis("Horizontal");
        float hiz = h * MovementSpeed;

        rb.velocity = new Vector2(hiz, rb.velocity.y);

    }

    void JumpFNC()
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
                rb.velocity = new Vector2(rb.velocity.x, JumpingPower);

            }
            else
            {
                if (CanJumpTwice)
                {
                    rb.velocity = new Vector2(rb.velocity.x, JumpingPower);
                    CanJumpTwice = false;
                }
                

            }


        }
        

    }

    void ChangeDirection()
    {
        Vector2 TemporaryScale = transform.localScale;

        if(rb.velocity.x>0)
        {
            direction = true;
            TemporaryScale.x = 1f;
        }else if(rb.velocity.x<0)
        {
            direction = false;
            TemporaryScale.x = -1f;
        }

        transform.localScale = TemporaryScale;    
    }

    public void KickBackFNC()
    {
        KickBackCounter = KickBackTime;
        rb.velocity = new Vector2(0, rb.velocity.y);

        anim.SetTrigger("damage");

    }

    public void JumpJumpFNC()
    {
        rb.velocity = new Vector2(rb.velocity.x, JumpJumpPower);
    }


}

