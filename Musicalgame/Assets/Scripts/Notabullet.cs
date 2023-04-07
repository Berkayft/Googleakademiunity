using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notabullet : MonoBehaviour
{
    public string notaninismi;
    public float destroysayac;
    public AudioSource notaninsesi;
    public GameObject dogruefekt;
    public GameObject yanlisefekt;
    
    void Start()
    {
        //bunlar simdilik böyle null da oyunu test ederken none olarak kalınca bazen hata veriyo
        dogruefekt  = null;
        yanlisefekt = null;
        notaninsesi = null;
    }

    
    void Update()
    {
        destroysayac -= Time.deltaTime;
        if(destroysayac < 0){
            Destroy(gameObject);
        }
    }
    
}
