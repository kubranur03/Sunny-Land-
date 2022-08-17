using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermicontroller : MonoBehaviour
{
    public float mermiHizi;

    PlayerHealtController playerHealtController;

    private void Awake()
    {
        playerHealtController = Object.FindObjectOfType<PlayerHealtController>();
    }

    private void Update()
    {
        transform.position += new Vector3(-mermiHizi *transform.localScale.x* Time.deltaTime, 0f, 0f);
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
