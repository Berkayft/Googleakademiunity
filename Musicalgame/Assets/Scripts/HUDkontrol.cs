using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDkontrol : MonoBehaviour
{
    public characterController cc;
    public Animator anim1;
    public Animation skill1;
    public Animator anim2;
    public Animation skill2;
    public Animator anim3;
    public Animation skill3;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //cooldown timerlar public yapıldıktan sonra anim.setBool("iscooling" , cc.cooldown) 
    }
}
