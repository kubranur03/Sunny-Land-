using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    public enum TankStates { Shoot, TakeABlow, Move, TankIsGone };
    public TankStates CurrentStaus;

    [SerializeField]
    Transform TankObject;

    public Animator anim;

    [Header("Movement")]
    public float MovementSpeed;
    public Transform LeftTarget, RightTarget;
    bool rightSide;

    [Header("Mine")]
    public GameObject Mine;
    public Transform MineCentrePoint;
    public float MineReleaseTime;
    float MineReleaseCounter;

    [Header("Shoot")]
    public GameObject Bullet;
    public Transform BulletCentre;
    public float BulletFiringTime;
    float BulletCounter;

    [Header("Impact")]
    public float PulseDuration;
    float PulseCounter;

    [Header("HealthStatus")]
    public int HealthStatus = 5;
    public GameObject TankExplosionEffect;
    bool WasHeDefeated;
    public float IncreaseBulletDuration, IncreaseMineLayingTime;

    public GameObject TankCrusherBox;


    private void Start()
    {
        CurrentStaus = TankStates.Shoot;

    }

    private void Update()
    {
        switch(CurrentStaus)
        {
            case TankStates.Shoot:
                //ateþ edildiðinde olacak olan durumlar

                BulletCounter -= Time.deltaTime;

                if (BulletCounter <= 0)
                {
                    BulletCounter = BulletFiringTime;
                    var NewBullet = Instantiate(Bullet, BulletCentre.position, BulletCentre.rotation);
                    NewBullet.transform.localScale = TankObject.localScale;
                }
                break;

            case TankStates.TakeABlow:
                //tank darbe aldýðýnda

                if (PulseCounter > 0)
                {
                    PulseCounter -= Time.deltaTime;

                    if (PulseCounter <= 0)
                    {
                        CurrentStaus = TankStates.Move;
                        MineReleaseCounter = 0;

                        if (WasHeDefeated)
                        {
                            TankObject.gameObject.SetActive(false);
                            Instantiate(TankExplosionEffect, transform.position, transform.rotation);


                            CurrentStaus = TankStates.TankIsGone;

                        }
                    }
                }
                break;


            case TankStates.Move:
                //tank hareket ettiðinde olacak durumlar

                if (rightSide)
                {
                    TankObject.position += new Vector3(MovementSpeed * Time.deltaTime, 0f, 0f);

                    if (TankObject.position.x > RightTarget.position.x)
                    {
                        TankObject.localScale = new Vector3(1, 1, 1);
                        rightSide = false;

                        StopTheMovementFNC();


                    }
                }
                else
                {
                    TankObject.position -= new Vector3(MovementSpeed * Time.deltaTime, 0f, 0f);
                    if (TankObject.position.x < LeftTarget.position.x)
                    {
                        TankObject.localScale = new Vector3(-1, 1, 1);
                        rightSide = true;

                        StopTheMovementFNC();

                    }
                }

                MineReleaseCounter -= Time.deltaTime;

                if(MineReleaseCounter <=0)
                {
                    MineReleaseCounter = MineReleaseTime;

                    Instantiate(Mine, MineCentrePoint.position, MineCentrePoint.rotation);
                }
                    break;

            
           

        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            TakeABlowFNC();
        }
    }



    public void TakeABlowFNC()
    {
        TankCrusherBox.SetActive(true);
        CurrentStaus = TankStates.TakeABlow;
        PulseCounter = PulseDuration;

        anim.SetTrigger("vur");

        mayincontroller[] mayinlar = FindObjectsOfType<mayincontroller>();

        if(mayinlar.Length>0)
        {
            foreach (mayincontroller bulunanmayin in mayinlar)
            {
                bulunanmayin.ExplosionFNC();
            }
        }

        HealthStatus--;

        if(HealthStatus <= 0)
        {
            WasHeDefeated = true;
        }
        else
        {
            BulletFiringTime /= IncreaseBulletDuration;
            MineReleaseTime /= IncreaseMineLayingTime;

        }


    }

    void StopTheMovementFNC()
    {
        CurrentStaus = TankStates.Shoot;
        BulletCounter = BulletFiringTime;

        anim.SetTrigger("stopmoving");


    }
}
