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


    Rigidbody2D rb;

    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        HareketEttirFNC();
        ZiplaFNC();
        YonuDegistir();
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
        anim.SetFloat("hareketHizi", Mathf.Abs(rb.velocity.x));
        anim.SetBool("yerdemi", Yerdemi);

    }

    void YonuDegistir()
    {
        Vector2 geciciScale = transform.localScale;

        if(rb.velocity.x>0)
        {
            geciciScale.x = 1f;
        }else if(rb.velocity.x<0)
        {
            geciciScale.x = -1f;
        }

        transform.localScale = geciciScale;    
    }
}

