using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hortum : MonoBehaviour
{
    public float donushizi;
    public GameObject player;

    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.back*Time.deltaTime*donushizi);
    }
    void FixedUpdate() {
        transform.position = player.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage, "Sol"); // düþman canýný azalt
        }
       
    }

}
