using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayincontroller : MonoBehaviour
{
    public GameObject patlamaEfekti;

    PlayerHealtController playerHealtController;

    private void Awake()
    {
        playerHealtController = Object.FindObjectOfType<PlayerHealtController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PatlamaFNC(); 

            playerHealtController.takeDamage();


        }
    }


    public void PatlamaFNC()
    {
        Destroy(this.gameObject);

        Instantiate(patlamaEfekti, transform.position, transform.rotation);
    }
}
