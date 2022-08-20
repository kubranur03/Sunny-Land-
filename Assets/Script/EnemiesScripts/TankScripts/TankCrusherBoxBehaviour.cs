using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCrusherBoxBehaviour : MonoBehaviour
{

    PlayerController playerController;

    TankBehaviour tankBehaviour;

    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        tankBehaviour = Object.FindObjectOfType<TankBehaviour>();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerController.transform.position.y > transform.position.y)
        {            
                playerController.JumpJump();

                tankBehaviour.TakeAblow();

                gameObject.SetActive(false);

            
        }
    }

}