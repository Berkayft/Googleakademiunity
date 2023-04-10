using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSecme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void levelYukle1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void levelYukle2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void levelYukle3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void levelYukle4()
    {
        SceneManager.LoadScene("Level4");
    }
}
