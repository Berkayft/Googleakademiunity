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
 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cooldown timerlar public yapıldıktan sonra anim.setBool("iscooling" , cc.cooldown) 
        anim1.SetBool("Iscooling", cc.isCooldown);
        // healing ve ulti için gelince buralar yapılacak
        healthbar.value = cc.heal;
    }
}
