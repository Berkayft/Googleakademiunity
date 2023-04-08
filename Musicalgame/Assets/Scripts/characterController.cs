using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Hareket hýzý
    private Rigidbody2D rb;//karakter rb
    private Vector2 movement; // hareket vektörü
   
    //ATEÞ ETME ILE ILGILI ****************************************************************

    [SerializeField] private GameObject bulletPrefab; // Kurþun prefabý
    [SerializeField] private Transform firePoint; // Ateþ noktasý
    [SerializeField] private float bulletSpeed = 10f; // Kurþun hýzý
    [SerializeField] private float fireRate = 0.5f; // Ateþ hýzý
    private float nextFireTime = 0f; // Bir sonraki ateþ zamaný
    private Vector2 target; // hedef - karakterin silahý


    //SPEED BOAST ILE ILGILI ******************************************************************

    public bool speedBoastActive ;
    [SerializeField] float boastSpeed = 20.0f;
    private float timer = 0f;
    private float duration = 2f;
    public float cooldown = 10f;
    private bool isCooldown = false;
    private float cooldownTimer = 0f;

    //SAGLIKLA ILGILI ****************************************************************************

    [SerializeField] private int heal = 100; // karakterin saðlýk deðeri
    private int maxHealth = 100; // karakterin maksimum saðlýk deðeri
    private bool isHealing = false; // iyileþtirme iþleminin devam edip etmediðini belirleyen bool deðiþken
    private float healAmount = 60f; // bir seferde iyileþtirme miktarý
    private float healTime = 0f; // iyileþtirme aralýðý
    private float healTimer = 0f; // iyileþtirme zamanlayýcýsý
    private float healCooldown = 0f; // iyileþtirme iþleminin bekleme süresi
    private float healCooldownTimer = 0f; // iyileþtirme iþleminin bekleme zamanlayýcýsý
    public int healthPoints ;


    //ULTI ILE ILGILI ****************************************************************************************

    public GameObject ultiBulletPrefab;
    public float ultiBulletSpeed;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
       takeMousePosition();
        movementData();
        shooterTimer();
        speedBoaster();
        healing();
        ultiShoot();
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


    void move() // HAREKET etme
    {
        if (speedBoastActive)
        {
            rb.MovePosition(rb.position + movement * boastSpeed * Time.fixedDeltaTime);

        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        }
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

    void speedBoaster() //hýzlanma
    {
        // Cooldown süresi dolmadan E tuþuna basýlamaz
        if (!isCooldown && Input.GetKeyDown(KeyCode.E))
        {
            // E tuþuna basýldýðýnda bool deðiþkenini true yap
            speedBoastActive = !speedBoastActive;
        }

        

        // Cooldown süresi dolduðunda isCooldown deðiþkenini false yap
        if (isCooldown)
        {
            cooldownTimer += Time.deltaTime;
            Debug.Log(cooldown);

            if (cooldownTimer >= cooldown)
            {
                isCooldown = false;
                cooldownTimer = 0f;
            }
        }

        // Bool deðiþkeni true olduðunda sayacý artýr
        if (speedBoastActive)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                // Süre dolduðunda bool deðiþkenini ve sayacý sýfýrla
                speedBoastActive = false;
                timer = 0f;
                isCooldown = true;
            }
        }


        /*  // E tuþuna basýldýðýnda bool deðiþkenini true yap
          if (Input.GetKeyDown(KeyCode.E))
          {
              speedBoastActive = !speedBoastActive;
          }



          // Bool deðiþkeni true olduðunda sayacý artýr
          if (speedBoastActive)
          {
              timer += Time.deltaTime;
              if (timer >= duration)
              {
                  speedBoastActive = false;
                  timer = 0f;
              }
          }*/
    }

    void healing()
    {
        if (healthPoints >0)
        {
            
            Debug.Log(heal);
            Debug.Log(healthPoints);

            // Q tuþuna basýldýðýnda ve iyileþtirme iþlemi yapma süresi geçmiþse
            if (Input.GetKeyDown(KeyCode.Q) && healCooldownTimer <= 0f && heal != 100)
            {
                isHealing = true;
                healthPoints--;

            }

            // Q tuþu býrakýldýðýnda iyileþtirme iþlemini durdur
            if (Input.GetKeyUp(KeyCode.Q) )
            {
                isHealing = false;
                healTimer = 0f; // iyileþtirme zamanlayýcýsýný sýfýrla
            }

            // iyileþtirme iþlemi devam ediyor mu?
            if (isHealing && heal < maxHealth)
            {
                healTimer += Time.deltaTime; // zamanlayýcýyý artýr

                // iyileþtirme aralýðýna ulaþýldýysa saðlýk deðerini artýr ve zamanlayýcýyý sýfýrla
                if (healTimer >= healTime)
                {
                    heal = Mathf.Min(heal + (int)healAmount, maxHealth); // saðlýk deðerini artýrýrken maksimum saðlýk deðerini geçme
                    healTimer = 0f;
                }
            }
            // iyileþtirme iþlemi yapýlmadýysa ve iyileþtirme iþlemi yapma süresi geçtiyse iyileþtirme iþlemini yapma süresini sýfýrla
            else if (healCooldownTimer <= 0f)
            {
                healCooldownTimer = healCooldown;
            }

            // iyileþtirme iþlemi yapma süresini azalt
            healCooldownTimer -= Time.deltaTime;
        }
    } //Iyileþme
    void ultiShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 18; i++)
            {
                GameObject BulletPrefab = Instantiate(ultiBulletPrefab, transform.position, Quaternion.identity);
                Rigidbody2D bulletRigidbody = BulletPrefab.GetComponent<Rigidbody2D>();
                float angle = i * 20f;
                bulletRigidbody.velocity = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * bulletSpeed;
            }
        }
    } //ulti

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           TakeDamage(10);
        }
    }


}








