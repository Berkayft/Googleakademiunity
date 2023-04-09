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

    [SerializeField] float damage = 5;
    
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



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); // mermiyi yok et
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage,notaninismi); // düşman canını azalt
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject); // mermiyi yok et
        }
        else
        {
            Destroy(gameObject); // mermiyi yok et

        }
    }


}
