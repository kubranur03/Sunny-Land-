using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField]
    Image heart1_img, heart2_img, heart3_img;


    [SerializeField]
    Sprite fullheart, halfheart, emptyheart;

    PlayerHealtController playerHealtController;

    private void Awake()
    {
        playerHealtController = Object.FindObjectOfType<PlayerHealtController>();

    }

    public void UpdateHealthStatus()
    {
        switch(playerHealtController.validHealt)
        {

            case 6:
                heart1_img.sprite = fullheart;
                heart2_img.sprite = fullheart;
                heart3_img.sprite = fullheart;
                break;

            case 5:
                heart1_img.sprite = fullheart;
                heart2_img.sprite = fullheart;
                heart3_img.sprite = halfheart;
                break;

            case 4:
                heart1_img.sprite = fullheart;
                heart2_img.sprite = fullheart;
                heart3_img.sprite = emptyheart;
                break;

            case 3:
                heart1_img.sprite = fullheart;
                heart2_img.sprite = halfheart;
                heart3_img.sprite = emptyheart;
                break;

            case 2:
                heart1_img.sprite = fullheart;
                heart2_img.sprite = emptyheart;
                heart3_img.sprite = emptyheart;
                break;

            case 1:
                heart1_img.sprite = halfheart;
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

}
