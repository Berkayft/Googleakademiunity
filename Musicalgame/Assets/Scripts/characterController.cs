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
    public float cooldownTimer = 10f;
    

    //SAGLIKLA ILGILI ****************************************************************************

    [SerializeField] public float heal = 100; // karakterin sa�l�k de�eri
    private float maxHealth = 100; // karakterin maksimum sa�l�k de�eri
    private float healAmount = 60f; // bir seferde iyile�tirme miktar�
    public int healthPoints ;
    public float healcooldownslider;


    //ULTI ILE ILGILI ****************************************************************************************

    public GameObject ultiBulletPrefab;
    public float ultiBulletSpeed;
    private float nextFireTimeUlti = 0.0f;
    public float fireDelayUlti;
    public float ultislider;
    public float cooldownsl;
    public float maincooldownsl;
    //Hud ile ilgili *********************************************
    public HUDkontrol hud;

    //Hortum yaratma ile ilgili*******************************************
    private float hortumzaman;
    public float mainhortumzaman;
    private float hortumcooldown;
    public float mainhortumcooldown;
    private bool ishortuming = false;
    public GameObject hortum;
    private bool ishortumcooldowning;
    public float hortumyaratmaslider;
    public float gecicihortumyaratmaslider;





    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletPrefab = notalar[0];
        hortumzaman = mainhortumzaman;
        hortumcooldown = mainhortumcooldown;
        nextFireTime = -50f;
        maincooldownsl = fireDelayUlti;
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
        Hortumyarat();
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

    public void TakeDamage(int damage) // hasar alma
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
                cooldownTimer = 0f;
            }
        }


      
       }

    void healing()
    {
        if (healthPoints >0)
        {
            
            

            // Q tu�una bas�ld���nda ve iyile�tirme i�lemi yapma s�resi ge�mi�se
            if (Input.GetKeyDown(KeyCode.Q) && heal != 100)
            {
                float gecicican = heal + healAmount;
                if(gecicican > maxHealth) {
                    heal = maxHealth;
                }else {
                    heal = gecicican;
                }
                healthPoints--;
                heal += 20;

            }

            
            
        }
    } //Iyile�me
    void ultiShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTimeUlti)
        {
            cooldownsl = 0;
            nextFireTimeUlti = Time.time + fireDelayUlti;
            // 8 yöne doğru birim vektörleri tanımlayalım
            Vector2[] directions = { Vector2.up, Vector2.down, Vector2.right, Vector2.left,
                                 new Vector2(1, 1).normalized, new Vector2(1, -1).normalized,
                                 new Vector2(-1, 1).normalized, new Vector2(-1, -1).normalized };

            // Mermileri 8 yöne doğru oluşturalım
            foreach (Vector2 direction in directions)
            {
                // Mermi pozisyonunu belirleyelim
                Vector2 bulletPos = (Vector2)transform.position + direction;

                // Mermiyi oluşturalım ve hızını ayarlayalım
                GameObject bullet = Instantiate(ultiBulletPrefab, bulletPos, Quaternion.identity);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = direction * bulletSpeed;
            }
        }
        if(cooldownsl < maincooldownsl) {
            cooldownsl += Time.deltaTime;
            
        }else {
            cooldownsl = maincooldownsl;
        }
        ultislider = cooldownsl;
    } //ulti*/

    private void OnCollisonEnter2D(Collider2D collision)
    {
        
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
            hud.Hudnotadegistir(suankinota);
        }
        
    }
    void Hortumyarat() {
        if(Input.GetKeyDown(KeyCode.Tab) && ishortumcooldowning == false) {
            hortum.SetActive(true);
            AudioSource asx = hortum.gameObject.GetComponent<AudioSource>();
            asx.Play();
            ishortuming = true;
        }
        if(ishortuming == true) {
            hortumzaman -= Time.deltaTime;
            if(hortumzaman < 0) {
                hortum.SetActive(false);
                ishortuming = false;
                ishortumcooldowning = true;
            }
        }
        if(ishortumcooldowning == true) {
            hortumcooldown -= Time.deltaTime;
            if(hortumcooldown < 0) {
                hortumzaman = mainhortumzaman;
                ishortumcooldowning = false;
                hortumcooldown = mainhortumcooldown;
            }
        }
        gecicihortumyaratmaslider = Mathf.Abs(hortumcooldown - mainhortumcooldown);
        if(gecicihortumyaratmaslider == 0) {
            hortumyaratmaslider = 50;
        }else {
            hortumyaratmaslider = gecicihortumyaratmaslider;
        }
    }


}








