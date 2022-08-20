using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehaviour : MonoBehaviour
{
    private TankStates currentStatus;

    [SerializeField] private Transform tankObject;

    public Animator animator;

    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform leftTargetTransform, rightTargetTransform;
    private bool isRightSide;

    [Header("Mine")]
    [SerializeField] private GameObject mineObject;
    [SerializeField] private Transform mineCentrePoint;
    [SerializeField] private float mineReleaseTime;
    private float mineReleaseCounter;

    [Header("Shoot")]
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Transform bulletCentreTransform;
    [SerializeField] private float bulletFiringTime;
    private float bulletCounter;

    [Header("Impact")]
    [SerializeField] private float pulseDuration;
    private float pulseCounter;

    [Header("HealthStatus")]
    private int healthStatus = 5;
    [SerializeField] private GameObject tankExplosionEffectObject;
    private bool wasDefeated;
    [SerializeField] private float increaseBulletDuration, increaseMineLayingTime;

    [SerializeField] private GameObject tankCrusherBoxObject;


    private void Start()
    {
        currentStatus = TankStates.Shoot;

    }

    private void Update()
    {
        switch (currentStatus)
        {
            case TankStates.Shoot:
                //ateþ edildiðinde olacak olan durumlar

                bulletCounter -= Time.deltaTime;

                if (bulletCounter <= 0)
                {
                    bulletCounter = bulletFiringTime;
                    var newBullet = Instantiate(bulletObject, bulletCentreTransform.position, bulletCentreTransform.rotation);
                    newBullet.transform.localScale = tankObject.localScale;
                }
                break;

            case TankStates.TakeABlow:
                //tank darbe aldýðýnda

                if (pulseCounter > 0)
                {
                    pulseCounter -= Time.deltaTime;

                    if (pulseCounter <= 0)
                    {
                        currentStatus = TankStates.Move;
                        mineReleaseCounter = 0;

                        if (wasDefeated)
                        {
                            tankObject.gameObject.SetActive(false);
                            Instantiate(tankExplosionEffectObject, transform.position, transform.rotation);


                            currentStatus = TankStates.TankIsGone;

                        }
                    }
                }
                break;


            case TankStates.Move:
                //tank hareket ettiðinde olacak durumlar

                if (isRightSide)
                {
                    tankObject.position += new Vector3(movementSpeed * Time.deltaTime, 0f, 0f);

                    if (tankObject.position.x > rightTargetTransform.position.x)
                    {
                        tankObject.localScale = new Vector3(1, 1, 1);
                        isRightSide = false;

                        StopTheMovement();


                    }
                }
                else
                {
                    tankObject.position -= new Vector3(movementSpeed * Time.deltaTime, 0f, 0f);
                    if (tankObject.position.x < leftTargetTransform.position.x)
                    {
                        tankObject.localScale = new Vector3(-1, 1, 1);
                        isRightSide = true;

                        StopTheMovement();

                    }
                }

                mineReleaseCounter -= Time.deltaTime;

                if (mineReleaseCounter <= 0)
                {
                    mineReleaseCounter = mineReleaseTime;

                    Instantiate(mineObject, mineCentrePoint.position, mineCentrePoint.rotation);
                }
                break;




        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeAblow();
        }
    }



    public void TakeAblow()
    {
        tankCrusherBoxObject.SetActive(true);
        currentStatus = TankStates.TakeABlow;
        pulseCounter = pulseDuration;

        animator.SetTrigger("vur");

        MineBehaviour[] mayinlar = FindObjectsOfType<MineBehaviour>();

        if (mayinlar.Length > 0)
        {
            foreach (MineBehaviour bulunanmayin in mayinlar)
            {
                bulunanmayin.Explosion();
            }
        }

        healthStatus--;

        if (healthStatus <= 0)
        {
            wasDefeated = true;
        }
        else
        {
            bulletFiringTime /= increaseBulletDuration;
            mineReleaseTime /= increaseMineLayingTime;

        }


    }

    void StopTheMovement()
    {
        currentStatus = TankStates.Shoot;
        bulletCounter = bulletFiringTime;

        animator.SetTrigger("stopmoving");


    }
}
