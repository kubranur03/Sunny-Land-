using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EziciKutuKontrol : MonoBehaviour
{


    [SerializeField]
    GameObject YokOlma;

    PlayerController playerController;

    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Kurbaga"))
        {
            other.transform.parent.gameObject.SetActive(false);
            Instantiate(YokOlma, transform.position, transform.rotation);

            playerController.ZiplaZiplaFNC();
        }
    }
}
