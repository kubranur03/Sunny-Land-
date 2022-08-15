using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    PlayerHealtController playerHealtController;
    private void Awake()
    {
        playerHealtController = Object.FindObjectOfType<PlayerHealtController>();   
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerHealtController.takeDamage();
        }
    }
}
