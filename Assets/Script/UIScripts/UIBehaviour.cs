using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField]
    Image heart1_img, heart2_img, heart3_img;


    [SerializeField]
    Sprite fullheart, emptyheart;

    PlayerHealtBehaviour playerHealtBehaviour;
    LevelManager levelManager;

    [SerializeField] private GameObject FadeScreen;


    [SerializeField] 
    TMP_Text JewelsTxt;


    private void Awake()
    {
        playerHealtBehaviour = Object.FindObjectOfType<PlayerHealtBehaviour>();
        levelManager = Object.FindObjectOfType<LevelManager>();

    }

    public void UpdateHealthStatus()
    {
        switch(playerHealtBehaviour.validHealt)
        {

            case 3:
                heart1_img.sprite = fullheart;
                heart2_img.sprite = fullheart;
                heart3_img.sprite = fullheart;
                break;
 

            case 2:
                heart1_img.sprite = fullheart;
                heart2_img.sprite = fullheart;
                heart3_img.sprite = emptyheart;
                break;
           
            case 1:
                heart1_img.sprite = fullheart;
                heart2_img.sprite = emptyheart;
                heart3_img.sprite = emptyheart;
                break;

            case 0:
                heart1_img.sprite = emptyheart;
                heart2_img.sprite = emptyheart;
                heart3_img.sprite = emptyheart;
                break;

        }
        
    }


    public void UpdateJewelCount()
    {
        JewelsTxt.text = levelManager.theNumberOfJewelsCollected.ToString();

    }

    public void OpenFadeScreen()
    {
        FadeScreen.GetComponent<CanvasGroup>().DOFade(1, .4f);
    }

   



}
