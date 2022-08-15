using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float HareketHizi;

    [SerializeField]
    float ZiplamaGucu;

    bool Yerdemi;
    public Transform zeminkontrolnoktasi;
    public LayerMask zeminLayer;
    bool ikikezziplayabilirmi;


    public float KickBackTime, KickBackStrength;
    float KickBackCounter;
    bool direction;


    Rigidbody2D rb;

    Animator anim;

    public float ZiplaZiplaGucu;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        if(KickBackCounter<=0)
        {

            HareketEttirFNC();
            ZiplaFNC();
            YonuDegistir();
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



        anim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
        anim.SetBool("yerdemi", Yerdemi);

    }

    void HareketEttirFNC()
    {
        float h = Input.GetAxis("Horizontal");
        float hiz = h * HareketHizi;

        rb.velocity = new Vector2(hiz, rb.velocity.y);

    }

    void ZiplaFNC()
    {
        Yerdemi = Physics2D.OverlapCircle(zeminkontrolnoktasi.position, .2f, zeminLayer);
        
        if(Yerdemi)
        {
            ikikezziplayabilirmi = true;
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(Yerdemi)
            {
                rb.velocity = new Vector2(rb.velocity.x, ZiplamaGucu);

            }
            else
            {
                if (ikikezziplayabilirmi)
                {
                    rb.velocity = new Vector2(rb.velocity.x, ZiplamaGucu);
                    ikikezziplayabilirmi = false;
                }
                

            }


        }
        

    }

    void YonuDegistir()
    {
        Vector2 geciciScale = transform.localScale;

        if(rb.velocity.x>0)
        {
            direction = true;
            geciciScale.x = 1f;
        }else if(rb.velocity.x<0)
        {
            direction = false;
            geciciScale.x = -1f;
        }

        transform.localScale = geciciScale;    
    }

    public void KickBackFNC()
    {
        KickBackCounter = KickBackTime;
        rb.velocity = new Vector2(0, rb.velocity.y);

        anim.SetTrigger("damage");

    }

    public void ZiplaZiplaFNC()
    {
        rb.velocity = new Vector2(rb.velocity.x, ZiplaZiplaGucu);
    }


}

