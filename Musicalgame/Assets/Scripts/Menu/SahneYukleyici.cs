using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneYukleyici : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SahneYukle();
        }
    }

    public void SahneYukle()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
