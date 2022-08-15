using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtController : MonoBehaviour
{
    public int maxHealt, validHealt;

    [SerializeField]
    GameObject disappearanceEffect;

    UIcontroller uicontroller;

    public float invincibilityTime;
    float invincibilityCounter;

    SpriteRenderer sr;

    PlayerController playerController;



    private void Awake()
    {

        playerController = Object.FindObjectOfType<PlayerController>();

        sr = GetComponent<SpriteRenderer>();
        uicontroller = Object.FindObjectOfType<UIcontroller>();

    }


    private void Start()
    {
        validHealt = maxHealt;
    }


    private void Update()
    {
        invincibilityCounter -= Time.deltaTime;

        if (invincibilityCounter <= 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);

        }

    }

    public void takeDamage()
    {
        if (invincibilityCounter <= 0)
        {
            validHealt--;

            if (validHealt <= 0)
            {
                validHealt = 0;
                gameObject.SetActive(false);
                Instantiate(disappearanceEffect, transform.position, transform.rotation);

            }
            else
            {
                invincibilityCounter = invincibilityTime ;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

                playerController.KickBackFNC();
            }

            uicontroller.UpdateHealthStatus();

        }

    }
}
