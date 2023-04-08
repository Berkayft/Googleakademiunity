using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f; // d��man�n h�z�
    public int damage = 1; // d��man�n verdi�i hasar

    [SerializeField] Transform target; // oyuncunun pozisyonu
    [SerializeField] GameObject player;
    private Rigidbody2D rb;
    

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
      
       
        
    }

    void FixedUpdate()
    {
        Vector2 direction = target.position - rb.transform.position; // oyuncuya do�ru y�n
        rb.velocity = direction.normalized * speed; // h�z� ayarla

        // d��man�n y�z�n� do�ru y�ne d�nd�r
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
    }

  
}
