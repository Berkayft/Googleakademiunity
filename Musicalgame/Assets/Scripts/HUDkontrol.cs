using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDkontrol : MonoBehaviour
{
    public characterController cc;
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
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
        anim1.SetBool("Iscooling", cc.isCooldown);
        // healing ve ulti için gelince buralar yapılacak
        healthbar.value = cc.heal;
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
