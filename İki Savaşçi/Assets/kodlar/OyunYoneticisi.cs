using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunYoneticisi : MonoBehaviour
{//tanılmalar
    public GameObject oyuncu1;//karakter 1'in image
    public GameObject oyuncu2;//karakter 2'nin image

    public int P1Life;//karakter 1'in canlarının tantımı
    public int P2Life;//karakter2'nin canlarının tantımı

    public GameObject P1Wins;//karakter 1 kazandı
    public GameObject P2Wins;//karakter 2 kazandı

    public GameObject[] p1Can;//karakter 1'in can görsellerinin eksilmesi için tanıtıldı
    public GameObject[] p2Can;//karakter 2'nin can görsellerinin eksilmesi için tanıtıldı

    public AudioSource HurtSes;//ses tanımlaması

    public string GirisEkrani;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (P1Life <= 0) // 1. oyuncunun canı 0 dan küçük ise
        {
            oyuncu1.SetActive(false); //oyuncu1 objesi devre dışı bırakldı
            P2Wins.SetActive(true); // 2.oyuncu kazandı objesi etkinleştirildi
            
            }

        if (P2Life <= 0) // 2. ouuncunun canı 0 dan küçük ise
        {
            oyuncu2.SetActive(false);//oyuncu1 objesi devre dışı bırakldı
            P1Wins.SetActive(true);//1. oyuncu kazandı objesi etkinleştirildi
        }
        //restart etme kodu
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           
        }
        // ESC tuşuna başarak giriş ekranına geri dönme kodu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(GirisEkrani);
        }

    }

    public void yaralamak1()
    {

        P1Life -= 1; // oyuncu 1'in canı 1 er 1 er azalmaktadır

        for (int i = 0; i < p1Can.Length; i++) 
        {
            if (P1Life > i) //1.oyucunun canı i'den küçük ise
            {
                p1Can[i].SetActive(true); // can görsellerini eksilt
            }
            else
            {
                p1Can[i].SetActive(false); //değil ise can görselini eksiltme
            }


        }
        HurtSes.Play(); //1.oyuncu için ses kodu
    }
    
    public void yaralamak2()
    {
        P2Life -= 1; //oyuncu 2'in canı 1 er 1 er azalmaktadır

        for (int i = 0; i < p2Can.Length; i++)
        {
            if (P2Life > i)//2.oyucunun canı i'den küçük ise
            {
                p2Can[i].SetActive(true);// can görsellerini eksilt
            }
            else
            {
                p2Can[i].SetActive(false);//değil ise can görselini eksiltme
            }
        }


        HurtSes.Play(); //2.oyuncu için ses kodu

    }
}



