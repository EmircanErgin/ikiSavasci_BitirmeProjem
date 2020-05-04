using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kartopu : MonoBehaviour
{
    //değiken tanımlamalar
    public float TopHizi;
    private Rigidbody2D theRB;
    public GameObject KartopuEfekt;


    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>(); //rigidbody bileşeni   
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(TopHizi * transform.localScale.x, 0);//kartopunun hızı ve yönü
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Oyuncu1")
        {
            FindObjectOfType<OyunYoneticisi>().yaralamak1();//oyuncu1 tagı döndürülür
        }
        if (other.tag == "Oyuncu2")
        {
            FindObjectOfType<OyunYoneticisi>().yaralamak2();//oyuncu2 tagı döndürülür
        }

        Instantiate(KartopuEfekt, transform.position, transform.rotation);//kartopu efekt


        Destroy(gameObject);//silme 
    
      }  

    }