using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Hareket hýzý
    private Rigidbody2D rb;//karakter rb
    private Vector2 movement; // hareket vektörü
    [SerializeField] private int heal = 100; // karakter caný
    


    [SerializeField] private GameObject bulletPrefab; // Kurþun prefabý
    [SerializeField] private Transform firePoint; // Ateþ noktasý
    [SerializeField] private float bulletSpeed = 10f; // Kurþun hýzý
    [SerializeField] private float fireRate = 0.5f; // Ateþ hýzý
    private float nextFireTime = 0f; // Bir sonraki ateþ zamaný
    private Vector2 target; // hedef - karakterin silahý

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
       takeMousePosition();
        movementData();
        shooterTimer();
    }

    private void FixedUpdate()
    {
        move();
    }

    void shooterTimer()   // Fare sol tuþuna basýlýrsa ve bir sonraki ateþ zamaný gelmiþse
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot(); // Ateþ et
            nextFireTime = Time.time + fireRate; // Bir sonraki ateþ zamanýný ayarla
        }
    }
    void Shoot()  // ateþ edioz
    {
        // Kurþun objesi oluþtur ve hedefe doðru fýrlat
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.velocity = transform.up * bulletSpeed;
    } 

    void movementData() //hareket için gereken datayý alýoz
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }


    void move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    } 

    void takeMousePosition()  // Fare pozisyonunu alýn ve karaktere göre düzeltin

    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = target - (Vector2)transform.position;
        transform.up = direction;
        
    }

    void TakeDamage(int damage) // hasar alma
    {
        heal -= damage;
        Debug.Log(heal);
        if (heal <= 0)
        {
            // Karakter öldüðünde yapýlacak iþlemler
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           TakeDamage(10);
        }
    }


}








