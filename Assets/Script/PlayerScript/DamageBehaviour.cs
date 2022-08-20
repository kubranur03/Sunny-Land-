using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehaviour : MonoBehaviour
{
    PlayerHealtBehaviour playerHealtController;
    private void Awake()
    {
        playerHealtController = Object.FindObjectOfType<PlayerHealtBehaviour>();   
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerHealtController.takeDamage();
        }
    }
}
