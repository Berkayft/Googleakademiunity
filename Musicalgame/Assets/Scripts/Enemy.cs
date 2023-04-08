using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f; // düþmanýn hýzý
    public int damage = 1; // düþmanýn verdiði hasar

    [SerializeField] Transform target; // oyuncunun pozisyonu
    [SerializeField] GameObject player;
    private Rigidbody2D rb;
    

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
      
       
        
    }

    void FixedUpdate()
    {
        Vector2 direction = target.position - rb.transform.position; // oyuncuya doðru yön
        rb.velocity = direction.normalized * speed; // hýzý ayarla

        // düþmanýn yüzünü doðru yöne döndür
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
