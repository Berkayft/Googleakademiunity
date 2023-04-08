using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globaldatas : MonoBehaviour
{
    public bool[] bulunankagitlar;
    void Awake() {
       DontDestroyOnLoad(gameObject); 
    }
}
