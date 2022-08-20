using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float BulletSpeed;

    PlayerHealtBehaviour playerHealtController;

    private void Awake()
    {
        playerHealtController = Object.FindObjectOfType<PlayerHealtBehaviour>();
    }

    private void Update()
    {
        transform.position += new Vector3(-BulletSpeed *transform.localScale.x* Time.deltaTime, 0f, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            playerHealtController.takeDamage();

        }

        Destroy(gameObject);


    }


}
