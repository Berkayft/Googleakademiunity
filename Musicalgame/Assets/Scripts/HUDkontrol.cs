using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDkontrol : MonoBehaviour
{
    public characterController cc;
    public Xskill xs;
    public Bosscontrol bs;
    public Slider skill1;
    public Slider skill2;
    public Slider skill3;
    public Slider skill4;
    public Slider bosscan;
    public Text potionsayi;
    
    public Slider healthbar;
    
    public GameObject[] notaresimleri;
 
    

    // Start is called before the first frame update
    void Start()
    {
        notaresimleri[0].SetActive(false);
        notaresimleri[1].SetActive(false);
        notaresimleri[2].SetActive(false);
        notaresimleri[cc.suankinota].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //cooldown timerlar public yapıldıktan sonra anim.setBool("iscooling" , cc.cooldown) 
        skill1.value = cc.cooldownTimer;
        skill2.value = cc.hortumyaratmaslider;
        skill3.value = cc.ultislider;
        skill4.value = xs.slidervalue;
        bosscan.value = bs.heal;
        // healing ve ulti için gelince buralar yapılacak
        healthbar.value = cc.heal;
        potionsayi.text = cc.healthPoints.ToString();
    }
    public void Hudnotadegistir(int x) {
        if(x == 0) {
            notaresimleri[0].SetActive(true);
            notaresimleri[1].SetActive(false);
            notaresimleri[2].SetActive(false);
        }else if(x == 1) {
            notaresimleri[0].SetActive(false);
            notaresimleri[1].SetActive(true);
            notaresimleri[2].SetActive(false);
        }else {
            notaresimleri[0].SetActive(false);
            notaresimleri[1].SetActive(false);
            notaresimleri[2].SetActive(true);
        }
    }
}
