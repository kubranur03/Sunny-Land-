using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBehaviour : MonoBehaviour
{
    public GameObject ExplosionEffect;

    PlayerHealtBehaviour playerHealtController;

    private void Awake()
    {
        playerHealtController = Object.FindObjectOfType<PlayerHealtBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Explosion();

            playerHealtController.takeDamage();


        }
    }


    public void Explosion()
    {
        Destroy(this.gameObject);

        Instantiate(ExplosionEffect, transform.position, transform.rotation);
    }
}
