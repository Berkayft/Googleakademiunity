using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosscontrol : MonoBehaviour
{
    public Rigidbody2D bossrb;
    public Rigidbody2D playerrb;
    public Vector2 aradakivektor;
    // mermi ***************************************************
    public GameObject mermiprefab;
    private float mermizaman;
    public float anamermizaman;
    public Transform spawnerpoint;
    public float bulletspeed;

    // can*******************************************************
    public float heal;

    
    // Start is called before the first frame update
    void Start()
    {
        mermizaman = anamermizaman;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        aradakivektor = playerrb.position - bossrb.position;
        float angle = Mathf.Atan2(aradakivektor.y,aradakivektor.x)*Mathf.Rad2Deg;
        bossrb.rotation = angle - 90f;

        mermizaman -= Time.fixedDeltaTime;
        if(mermizaman < 0f) {
            GameObject suankibullet = Instantiate(mermiprefab, spawnerpoint.position,spawnerpoint.rotation);
            Rigidbody2D sbrb = suankibullet.gameObject.GetComponent<Rigidbody2D>();
            sbrb.velocity = aradakivektor.normalized * bulletspeed;
            mermizaman = anamermizaman;
        }
    }
    public void TakeDamageboss(float x) {
        heal -= x;
    }
    
}
