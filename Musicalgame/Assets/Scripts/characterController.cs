using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Hareket h�z�
    private Rigidbody2D rb;//karakter rb
    private Vector2 movement; // hareket vekt�r�
    [SerializeField] private int heal = 100; // karakter can�
    


    [SerializeField] private GameObject bulletPrefab; // Kur�un prefab�
    [SerializeField] private Transform firePoint; // Ate� noktas�
    [SerializeField] private float bulletSpeed = 10f; // Kur�un h�z�
    [SerializeField] private float fireRate = 0.5f; // Ate� h�z�
    private float nextFireTime = 0f; // Bir sonraki ate� zaman�
    private Vector2 target; // hedef - karakterin silah�

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

    void shooterTimer()   // Fare sol tu�una bas�l�rsa ve bir sonraki ate� zaman� gelmi�se
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot(); // Ate� et
            nextFireTime = Time.time + fireRate; // Bir sonraki ate� zaman�n� ayarla
        }
    }
    void Shoot()  // ate� edioz
    {
        // Kur�un objesi olu�tur ve hedefe do�ru f�rlat
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.velocity = transform.up * bulletSpeed;
    } 

    void movementData() //hareket i�in gereken datay� al�oz
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }


    void move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    } 

    void takeMousePosition()  // Fare pozisyonunu al�n ve karaktere g�re d�zeltin

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
            // Karakter �ld���nde yap�lacak i�lemler
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








