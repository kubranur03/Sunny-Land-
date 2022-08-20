using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    Transform targetTransform;

    [SerializeField]
     private float minY, maxY;


    Vector2 LastPos;



    private void Start()
    {

        LastPos = transform.position;
    }

    private void Update()
    {

        LimitCameraFNC();
        MoveToFloorsFNC();

    }

    void LimitCameraFNC()
    {
        transform.position = new Vector3(targetTransform.position.x,
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z);
    }

    void MoveToFloorsFNC()
    {
        Vector2 AmountInBetween = new Vector2(transform.position.x - LastPos.x, transform.position.y - LastPos.y);

        // altZemin.position += new Vector3(aradakiMiktar.x, aradakiMiktar.y, 0f);
        // MediumGround.position += new Vector3(AmountInBetween.x, AmountInBetween.y, 0f)*.5f;

        LastPos = transform.position;

    }


}
