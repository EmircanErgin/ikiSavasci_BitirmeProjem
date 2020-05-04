using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakter_1 : MonoBehaviour
{
    //haraket ve atlama gücü tanımlandı
    public float hareketHizi;
    public float atlamaGucu;
    //karakterin haraketleri tanımlandı
    public KeyCode sol;
    public KeyCode sag;
    public KeyCode ziplama;
    public KeyCode atisTopu;
   
    //yer çekimi tanımlandı
    private Rigidbody2D RB;

    //konum tanımladı
    public Transform yerKontrolNoktasi;

    public float zemKontYaricap;
    // katman tanımladı
    public LayerMask zemin;

    public bool isGrounded;
    //animasyon tanımlandı
    private Animator anim;

    public GameObject Kartopu;
    public Transform AtisNoktasi;
    //ses efekti tanımlandı
    public AudioSource yurumses;

    // Start is called before the first frame update
    void Start()
    {
        //yerçekimi kodu
        RB = GetComponent<Rigidbody2D>();
        //animasyon kodu
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(yerKontrolNoktasi.position, zemKontYaricap, zemin);//karakterin zeminde kaymasını engeller
        if (Input.GetKey(sol))//sol yönünde karakterin ilerlemesi
        {
            RB.velocity = new Vector2(-hareketHizi, RB.velocity.y);
        }
        else if (Input.GetKey(sag)) //sağ yönünde karakterin ilerlemesi
        {
            RB.velocity = new Vector2(hareketHizi, RB.velocity.y);
        }else
        {
            RB.velocity = new Vector2(0, RB.velocity.y); //Karakterin durması
        }
        if (Input.GetKeyDown(ziplama) && isGrounded)//karakterin zıplaması
        {
            RB.velocity = new Vector2(RB.velocity.x, atlamaGucu);//Karakterin zıplama gücü
        }
        if(Input.GetKeyDown(atisTopu))//Karakterin ateş etmesi
        {
            //Karakterin ateş etme pozisyon ve rotasyonu
            GameObject ballClone = (GameObject)Instantiate(Kartopu, AtisNoktasi.position, AtisNoktasi.rotation);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Yurume");//animasyon yürümesini tetikler

            yurumses.Play();// sesin oynatılması
        }

        if (RB.velocity.x < 0)
        {
            //"x" 0dan küçük ise 
            transform.localScale = new Vector3(-1, 1, 1);
        }else if(RB.velocity.x > 0)
        {
            //"x" 0 dan büyük ise 
            transform.localScale = new Vector3(1, 1, 1);
        }
        //Mutlak değerini döndürür
        anim.SetFloat("Hiz", Mathf.Abs(RB.velocity.x));
        anim.SetBool("Havalanmayan", isGrounded);
  
    }
    
}

