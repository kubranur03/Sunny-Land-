using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    public enum TankdDurumlari { atesEtme, darbeAlma, hareketEtme };
    public TankdDurumlari gecerliDurum;

    [SerializeField]
    Transform TankObje;

    public Animator anim;

    [Header("Hareket")]
    public float hareketHizi;
    public Transform solhedef, saghedef;
    bool rightSide;

    [Header("AteþEtme")]
    public GameObject mermi;
    public Transform mermiMerkezi;
    public float mermiAtmaSuresi;
    float mermiSayaci;

    [Header("Darbe")]
    public float darbeSuresi;
    float darbesayaci;


    private void Start()
    {
        gecerliDurum = TankdDurumlari.atesEtme;

    }

    private void Update()
    {
        switch(gecerliDurum)
        {
            case TankdDurumlari.atesEtme:
                //ateþ edildiðinde olacak olan durumlar
                break;

            case TankdDurumlari.darbeAlma:
                //tank darbe aldýðýnda

                if (darbesayaci > 0)
                {
                    darbesayaci -= Time.deltaTime;

                    if (darbesayaci <= 0)
                    {
                        gecerliDurum = TankdDurumlari.hareketEtme;
                    }
                }
                break;


            case TankdDurumlari.hareketEtme:
                //tank hareket ettiðinde olacak durumlar

                if (rightSide)
                {
                    TankObje.position += new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);

                    if (TankObje.position.x > saghedef.position.x)
                    {
                        TankObje.localScale = new Vector3(1, 1, 1);
                        rightSide = false;
                        gecerliDurum = TankdDurumlari.atesEtme;
                        mermiSayaci = mermiAtmaSuresi;

                        anim.SetTrigger("stopmoving");


                    }
                }
                else
                {
                    TankObje.position -= new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);
                    if (TankObje.position.x < solhedef.position.x)
                    {
                        TankObje.localScale = new Vector3(-1, 1, 1);
                        rightSide = true;
                        gecerliDurum = TankdDurumlari.atesEtme;
                        mermiSayaci = mermiAtmaSuresi;

                        anim.SetTrigger("stopmoving");

                    }
                }
                    break;

            
           

        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            DarbeAlFNC();
        }
    }



    public void DarbeAlFNC()
    {
        gecerliDurum = TankdDurumlari.darbeAlma;
        darbesayaci = darbeSuresi;

        anim.SetTrigger("vur");
    }
}
