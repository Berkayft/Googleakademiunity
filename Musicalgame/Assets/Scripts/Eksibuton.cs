using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eksibuton : MonoBehaviour
{
    public Sayfakontrol sk;
    public int suankikagit;
    
    public void Eksi() {
        suankikagit = sk.suankisayfa;
        for(int i = suankikagit-1; i > -1 ; i--) {
            if(sk.bulunankagitlar[i] == true) {
                sk.kagitlar[sk.suankisayfa].SetActive(false);
                suankikagit = i;
                sk.suankisayfa = suankikagit;
                sk.kagitlar[suankikagit].SetActive(true);
                break;
            }
        }
    }
}
