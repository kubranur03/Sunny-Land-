using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerHealtBehaviour : MonoBehaviour
{
    public int maxHealt, validHealt;
    public bool gameOver;


    [SerializeField]
    GameObject gameOverPanel;

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
        gameOverPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        gameOverPanel.GetComponent<CanvasGroup>().alpha = 0;
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
                AudioManager.instance.MakeASoundEffect(2);
                GameOver();

            }
            else
            {
                invincibilityCounter = invincibilityTime ;
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);

                AudioManager.instance.MakeASoundEffect(1);
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

    public void GameOver()
    {
        gameOver = true;
        gameOverPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        gameOverPanel.GetComponent<RectTransform>().DOScale(1, 0.5f);


    }
}
