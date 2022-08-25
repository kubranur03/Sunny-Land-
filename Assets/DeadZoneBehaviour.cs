using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform playerTransform;

    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x+5f, transform.position.y, transform.position.z);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealtBehaviour>().GameOver();

        }
    }
}
