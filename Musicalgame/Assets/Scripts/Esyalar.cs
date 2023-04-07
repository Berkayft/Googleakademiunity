using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esyalar : MonoBehaviour
{
    public int esyatipi;
    public string dogrunota; 
    public GameObject yokolmaanim;
    // Start is called before the first frame update
    void Start()
    {
        yokolmaanim = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Nota") {
            //esya tipine göre her notaya göre kırılabilir ya da spesifik bir notaya göre kırılabilir
            if(esyatipi == 0 ) {
                Destroy(gameObject);
            }else{
                if(dogrunota == other.gameObject.GetComponent<Notabullet>().notaninismi) {
                    Destroy(gameObject);
                    //dogru nota animasyonu
                }else {
                    //yanlis nota animasyonu
                }
            }
        }
    }
}
