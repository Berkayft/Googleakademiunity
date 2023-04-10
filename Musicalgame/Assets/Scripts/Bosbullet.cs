using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosbullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
             characterController cc = other.gameObject.GetComponent<characterController>();
             cc.TakeDamage(30);
             Destroy(gameObject);
        }
    }
}
