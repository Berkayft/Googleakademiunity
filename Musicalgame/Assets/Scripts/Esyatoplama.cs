using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esyatoplama : MonoBehaviour
{
    public int esyatipi;
    //esya tipi 1 potion esya tipi 2,3,4,5 kagıtlar
    public Sayfakontrol sk;
    public characterController cc;
    public GameObject vtusu;
    public bool oyuncuicerde;
    void Start() {
        cc = GameObject.FindGameObjectWithTag("Player").GetComponent<characterController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            oyuncuicerde = true;
        }
    }
    void OnTriggerStay2D(Collider2D other) {
        if(other.tag == "Player")  {
            oyuncuicerde = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player") {
            oyuncuicerde = false;
        }
    }
    void Update() {
        if(oyuncuicerde == true) {
            vtusu.SetActive(true);
            if(Input.GetKeyDown(KeyCode.V)) {
                if(esyatipi == 1) {
                    cc.healthPoints ++;
                    Destroy(gameObject);
                }else if(esyatipi == 2) {
                    sk.bulunankagitlar[1] = true;
                    Destroy(gameObject);
                }
            }
        }else {
            vtusu.SetActive(false);
        }
    }
    
}
