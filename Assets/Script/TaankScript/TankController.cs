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

    [Header("Mayin")]
    public GameObject Mayin;
    public Transform MayinMerkezNoktasi;
    public float MayinBirakmaSüresi;
    float MayinBirakmaSayac;

    [Header("AteþEtme")]
    public GameObject mermi;
    public Transform mermiMerkezi;
    public float mermiAtmaSuresi;
    float mermiSayaci;

    [Header("Darbe")]
    public float darbeSuresi;
    float darbesayaci;

    public GameObject tankEziciKutu;


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

                mermiSayaci -= Time.deltaTime;

                if (mermiSayaci <= 0)
                {
                    mermiSayaci = mermiAtmaSuresi;
                    var yeniMermi = Instantiate(mermi, mermiMerkezi.position, mermiMerkezi.rotation);
                    yeniMermi.transform.localScale = TankObje.localScale;
                }
                break;

            case TankdDurumlari.darbeAlma:
                //tank darbe aldýðýnda

                if (darbesayaci > 0)
                {
                    darbesayaci -= Time.deltaTime;

                    if (darbesayaci <= 0)
                    {
                        gecerliDurum = TankdDurumlari.hareketEtme;
                        MayinBirakmaSayac = 0;
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

                        HareketiDurdurFNC();


                    }
                }
                else
                {
                    TankObje.position -= new Vector3(hareketHizi * Time.deltaTime, 0f, 0f);
                    if (TankObje.position.x < solhedef.position.x)
                    {
                        TankObje.localScale = new Vector3(-1, 1, 1);
                        rightSide = true;

                        HareketiDurdurFNC();

                    }
                }

                MayinBirakmaSayac -= Time.deltaTime;

                if(MayinBirakmaSayac <=0)
                {
                    MayinBirakmaSayac = MayinBirakmaSüresi;

                    Instantiate(Mayin, MayinMerkezNoktasi.position, MayinMerkezNoktasi.rotation);
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
        tankEziciKutu.SetActive(true);
        gecerliDurum = TankdDurumlari.darbeAlma;
        darbesayaci = darbeSuresi;

        anim.SetTrigger("vur");

        mayincontroller[] mayinlar = FindObjectsOfType<mayincontroller>();

        if(mayinlar.Length>0)
        {
            foreach (mayincontroller bulunanmayin in mayinlar)
            {
                bulunanmayin.PatlamaFNC();
            }
        }



    }

    void HareketiDurdurFNC()
    {
        gecerliDurum = TankdDurumlari.atesEtme;
        mermiSayaci = mermiAtmaSuresi;

        anim.SetTrigger("stopmoving");


    }
}
