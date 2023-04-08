using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hortum : MonoBehaviour
{
    public float donushizi;
    public GameObject player;
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
}
