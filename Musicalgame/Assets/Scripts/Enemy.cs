using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f; // d��man�n h�z�
    public int damage = 1; // d��man�n verdi�i hasar

    [SerializeField] Transform target; // oyuncunun pozisyonu
    private Rigidbody2D rb;

    public float enemyHealth = 20; // D��man�n can�

    public int dusmantipi;
    public float maksuzaklik;
    public Transform spawnpoint;


    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
      
       
        
    }

    void FixedUpdate()
    {
        Vector2 direction = target.position - rb.transform.position; // oyuncuya do�ru y�n
        if(direction.magnitude > maksuzaklik){
            Vector2 gotospawnpoint = transform.position - rb.transform.position;
            rb.velocity = gotospawnpoint.normalized * speed;
        }else {
            float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
            rb.rotation = angle - 90f;
            rb.velocity = direction.normalized * speed; // h�z� ayarla
            
        }

        
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


        public void TakeDamage(float a, string isim)
        {
            if (dusmantipi == 0)
            {
                enemyHealth -= a;
            }
            else if (dusmantipi == 1 && isim == "Do")
            {
                enemyHealth -= a;
            }
            else if (dusmantipi == 2 && isim == "Re")
            {
                enemyHealth -= a;
            }
            else if (dusmantipi == 3 && isim == "Mi")
            {
                enemyHealth -= a;
            }
            else if (isim == "Sol")
            {
                enemyHealth -= a;
            }

            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

    public void ultiDamage(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    
}
