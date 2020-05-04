using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GirisEkrani : MonoBehaviour { 
    //string adında tanımlamalar 
    public string Level1;
    public string Level2;
    public string oyunHakkinda;
    public string AnaMenu;

    public void BaslaLevel1() 
    {
    SceneManager.LoadScene(Level1);//giriş ekranından Level1 ekranına gidebilmesi için
    }

    public void BaslaLevel2()
    {
        SceneManager.LoadScene(Level2);
    }
    public void oyunBilgi()
    {
        SceneManager.LoadScene(oyunHakkinda);
    }
    public void AnaMenuu()
    {
        SceneManager.LoadScene(AnaMenu);
    }
    public void Cikis()
    {
        Application.Quit(); 
    }
}
