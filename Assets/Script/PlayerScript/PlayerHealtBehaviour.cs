using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealtBehaviour : MonoBehaviour
{
    public int maxHealt, validHealt;

    [SerializeField]
    GameObject disappearanceEffectObject;

    UIBehaviour uicontroller;

    [SerializeField] private float invincibilityTime;
    private float invincibilityCounter;

    SpriteRenderer spriteRenderer;

    PlayerController playerController;



    private void Awake()
    {

        playerController = Object.FindObjectOfType<PlayerController>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        uicontroller = Object.FindObjectOfType<UIBehaviour>();

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
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);

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
                Instantiate(disappearanceEffectObject, transform.position, transform.rotation);

            }
            else
            {
                invincibilityCounter = invincibilityTime ;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);

                playerController.KickBack();
            }

            uicontroller.UpdateHealthStatus();

        }

    }

    public void IncreaseHealth()
    {
        validHealt++;

        if(validHealt >= maxHealt)
        {
            validHealt = maxHealt;
        }
        uicontroller.UpdateHealthStatus();

    }
}
