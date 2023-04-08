using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Hareket h�z�
    private Rigidbody2D rb;//karakter rb
    private Vector2 movement; // hareket vekt�r�

    //Nota degistirme ile ilgili *******************************************************
    public int suankinota;
    public GameObject[] notalar;
   
    //ATE� ETME ILE ILGILI ****************************************************************

    [SerializeField] private GameObject bulletPrefab; // Kur�un prefab�
    [SerializeField] private Transform firePoint; // Ate� noktas�
    [SerializeField] private float bulletSpeed = 10f; // Kur�un h�z�
    [SerializeField] private float fireRate = 0.5f; // Ate� h�z�
    private float nextFireTime = 0f; // Bir sonraki ate� zaman�
    private Vector2 target; // hedef - karakterin silah�


    //SPEED BOAST ILE ILGILI ******************************************************************

    public bool speedBoastActive ;
    [SerializeField] float boastSpeed = 20.0f;
    private float timer = 0f;
    private float duration = 2f;
    public float cooldown = 10f;
    public bool isCooldown = false;
    private float cooldownTimer = 0f;

    //SAGLIKLA ILGILI ****************************************************************************

    [SerializeField] public int heal = 100; // karakterin sa�l�k de�eri
    private int maxHealth = 100; // karakterin maksimum sa�l�k de�eri
    public bool isHealing = false; // iyile�tirme i�leminin devam edip etmedi�ini belirleyen bool de�i�ken
    private float healAmount = 60f; // bir seferde iyile�tirme miktar�
    private float healTime = 0f; // iyile�tirme aral���
    private float healTimer = 0f; // iyile�tirme zamanlay�c�s�
    private float healCooldown = 0f; // iyile�tirme i�leminin bekleme s�resi
    private float healCooldownTimer = 0f; // iyile�tirme i�leminin bekleme zamanlay�c�s�
    public int healthPoints ;


    //ULTI ILE ILGILI ****************************************************************************************

    public GameObject ultiBulletPrefab;
    public float ultiBulletSpeed;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletPrefab = notalar[0];
    }


    void Update()
    {
       takeMousePosition();
        movementData();
        shooterTimer();
        speedBoaster();
        healing();
        ultiShoot();
        Notadegistir();
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

    void speedBoaster() //h�zlanma
    {
        // Cooldown s�resi dolmadan E tu�una bas�lamaz
        if (!isCooldown && Input.GetKeyDown(KeyCode.E))
        {
            // E tu�una bas�ld���nda bool de�i�kenini true yap
            speedBoastActive = !speedBoastActive;
        }

        

        // Cooldown s�resi doldu�unda isCooldown de�i�kenini false yap
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

        // Bool de�i�keni true oldu�unda sayac� art�r
        if (speedBoastActive)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                // S�re doldu�unda bool de�i�kenini ve sayac� s�f�rla
                speedBoastActive = false;
                timer = 0f;
                isCooldown = true;
            }
        }


        /*  // E tu�una bas�ld���nda bool de�i�kenini true yap
          if (Input.GetKeyDown(KeyCode.E))
          {
              speedBoastActive = !speedBoastActive;
          }



          // Bool de�i�keni true oldu�unda sayac� art�r
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

            // Q tu�una bas�ld���nda ve iyile�tirme i�lemi yapma s�resi ge�mi�se
            if (Input.GetKeyDown(KeyCode.Q) && healCooldownTimer <= 0f && heal != 100)
            {
                isHealing = true;
                healthPoints--;

            }

            // Q tu�u b�rak�ld���nda iyile�tirme i�lemini durdur
            if (Input.GetKeyUp(KeyCode.Q) )
            {
                isHealing = false;
                healTimer = 0f; // iyile�tirme zamanlay�c�s�n� s�f�rla
            }

            // iyile�tirme i�lemi devam ediyor mu?
            if (isHealing && heal < maxHealth)
            {
                healTimer += Time.deltaTime; // zamanlay�c�y� art�r

                // iyile�tirme aral���na ula��ld�ysa sa�l�k de�erini art�r ve zamanlay�c�y� s�f�rla
                if (healTimer >= healTime)
                {
                    heal = Mathf.Min(heal + (int)healAmount, maxHealth); // sa�l�k de�erini art�r�rken maksimum sa�l�k de�erini ge�me
                    healTimer = 0f;
                }
            }
            // iyile�tirme i�lemi yap�lmad�ysa ve iyile�tirme i�lemi yapma s�resi ge�tiyse iyile�tirme i�lemini yapma s�resini s�f�rla
            else if (healCooldownTimer <= 0f)
            {
                healCooldownTimer = healCooldown;
            }

            // iyile�tirme i�lemi yapma s�resini azalt
            healCooldownTimer -= Time.deltaTime;
        }
    } //Iyile�me
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
    void Notadegistir() {
        if(Input.GetKeyDown(KeyCode.F)) {
            if(suankinota == 2) {
                suankinota = 0;
                bulletPrefab = notalar[suankinota];
                
            }else {
                suankinota ++;
                bulletPrefab = notalar[suankinota];
            }
        }
        
    }


}








