using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melodilikapi : MonoBehaviour
{

    public string nota1;
    public string nota2;
    public string nota3;
    public string nota4;
    public string nota5;
    public string nota6;
    public string nota7;
    public string gelennota;
    public float dogrunota;
    public bool kapiacildimi;
    private float sayac;
    public float sayacmain;
    public BoxCollider2D bc;
    
    // Start is called before the first frame update
    void Start()
    {
        kapiacildimi = false;
        gelennota = null;
        dogrunota = 0;
        sayac = sayacmain;
        bc = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(kapiacildimi == false) {
            if(dogrunota == 0) {
                
            }else{
                sayac -= Time.deltaTime;
                if(sayac <= 0) {
                    dogrunota = 0;
                    sayac = sayacmain;
                }
            }
        }
    }

    void Open() {
        //kapinin animasyon ve colliderini kapatma kısmı burada olacak
        bc.enabled = false;
    }
    // nota ile carpisinca gelen notanin ismini alabilmek için 
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Nota") {
            Notabullet nb = other.gameObject.GetComponent<Notabullet>();
            gelennota = nb.notaninismi;
            Notageldi();

        }
    }
    //hangi notanın geldiğine göre kapının kilitini ilerletiyoruz işte do do do re re gibi en sonda da open var 
    void Notageldi() {
        if(dogrunota == 0) {
            if(gelennota == nota1) {
                
                dogrunota ++;
                sayac = sayacmain;
                gelennota = null;
            }else {
                gelennota = null;
                dogrunota = 0;
            }
        }else if(dogrunota == 1) {
            if(gelennota == nota2) {
                dogrunota ++;
                sayac = sayacmain;
                gelennota = null;
            }else {
                dogrunota = 0;
                gelennota = null;
            }
        }else if(dogrunota == 2) {
            if(gelennota == nota3) {
                dogrunota ++;
                sayac = sayacmain;
                gelennota = null;
            }else {
                gelennota = null;
                dogrunota = 0;
                
            }
        }else if(dogrunota == 3) {
            if(gelennota == nota4) {
                dogrunota ++;
                sayac = sayacmain;
                gelennota = null;
            }else {
                gelennota = null;
                dogrunota = 0;
            }
        }else if(dogrunota == 4) {
            if(gelennota == nota5) {
                dogrunota ++;
                sayac = sayacmain;
                gelennota = null;
            }else {
                gelennota = null;
                dogrunota = 0;
            }
        }else if(dogrunota == 5) {
            if(gelennota == nota6) {
                dogrunota ++;
                sayac = sayacmain;
                gelennota = null;
            }else {
                gelennota = null;
                dogrunota = 0;
            }
        }else if(dogrunota == 6) {
            if(gelennota == nota7) {
                dogrunota ++;
                sayac = sayacmain;
                kapiacildimi = true;
                Open();
            }else {
                dogrunota = 0;
            }
        }
    }
}
