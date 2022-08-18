using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mayincontroller : MonoBehaviour
{
    public GameObject ExplosionEffect;

    PlayerHealtController playerHealtController;

    private void Awake()
    {
        playerHealtController = Object.FindObjectOfType<PlayerHealtController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ExplosionFNC(); 

            playerHealtController.takeDamage();


        }
    }


    public void ExplosionFNC()
    {
        Destroy(this.gameObject);

        Instantiate(ExplosionEffect, transform.position, transform.rotation);
    }
}
