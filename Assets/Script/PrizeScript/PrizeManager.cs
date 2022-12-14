using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{

    PlayerHealtBehaviour playerHealtBehaviour;

    [SerializeField]
    bool isItJewel, isItCherry;

    [SerializeField]
    GameObject collection;


    private bool hasItGathered;

    LevelManager levelManager;
    UIBehaviour uIBehaviour;

    private void Awake()
    {
        levelManager = Object.FindObjectOfType<LevelManager>();
        uIBehaviour = Object.FindObjectOfType<UIBehaviour>();
        playerHealtBehaviour = Object.FindObjectOfType<PlayerHealtBehaviour>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !hasItGathered)
        {

            if (isItJewel)
            {
                levelManager.theNumberOfJewelsCollected++;

                hasItGathered = true;
                Destroy(gameObject);

                uIBehaviour.UpdateJewelCount();

                Instantiate(collection, transform.position, transform.rotation);
                AudioManager.instance.MakeASoundEffect(7);


            }

            if (isItCherry)
            {
                if(playerHealtBehaviour.validHealt != playerHealtBehaviour.maxHealt)
                {
                    hasItGathered = true;
                    Destroy(gameObject);

                    playerHealtBehaviour.IncreaseHealth();

                    Instantiate(collection, transform.position, transform.rotation);
                    AudioManager.instance.MakeASoundEffect(4);

                }

            }
           
        }
        
    }

}
