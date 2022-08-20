using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{

    PlayerHealtBehaviour playerHealtBehaviour;

    [SerializeField]
    bool ýsItJewel, isItCherry;

     private bool hasItGathered;

    LevelManager levelManager;
    UIBehaviour uicontroller;

    private void Awake()
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        uicontroller = Object.FindObjectOfType<UIBehaviour>();
        playerHealtBehaviour = Object.FindObjectOfType<PlayerHealtBehaviour>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !hasItGathered)
        {

            if (ýsItJewel)
            {
                levelManager.theNumberOfJewelsCollected++;

                hasItGathered = true;
                Destroy(gameObject);

                uicontroller.UpdateJewelCount();

            }

            if (isItCherry)
            {
                if(playerHealtBehaviour.validHealt != playerHealtBehaviour.maxHealt)
                {
                    hasItGathered = true;
                    Destroy(gameObject);

                    playerHealtBehaviour.IncreaseHealth();


                }

            }
           
        }
        
    }

}
