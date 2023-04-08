using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sayfakontrol : MonoBehaviour
{
    public int suankisayfa;
    public GameObject[] kagitlar;
    public GameObject kitap;
    public bool[] bulunankagitlar;
    public Globaldatas datas;
    // Start is called before the first frame update
    void Start()
    {
        kitap.SetActive(false);
        bulunankagitlar[0] = datas.bulunankagitlar[0];
        bulunankagitlar[1] = datas.bulunankagitlar[1];
        bulunankagitlar[2] = datas.bulunankagitlar[2];
        bulunankagitlar[3] = datas.bulunankagitlar[3];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) {
            if(kitap.activeSelf == false) {
                Time.timeScale = 0;
                kitap.SetActive(true);
            }else {
                Time.timeScale = 1;
                kitap.SetActive(false);
            }
        }
    }
}
