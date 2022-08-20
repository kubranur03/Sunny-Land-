using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherBoxBehaviour : MonoBehaviour
{


    [SerializeField]
    GameObject Extinction;

    PlayerController playerController;

    public float chanceOfCherry;

    public GameObject cherryObject;

    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kurbaga"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(Extinction, transform.position, transform.rotation);

            playerController.JumpJump();

            float dropoutInterval = Random.Range(0f, 100f);

            if(dropoutInterval<= chanceOfCherry)
            {
                Instantiate(cherryObject, other.transform.position, other.transform.rotation);
            }
        }
             
    }
}
