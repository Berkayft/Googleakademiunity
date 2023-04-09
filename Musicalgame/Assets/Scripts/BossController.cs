using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bulletPrefab; // at�� prefab'�
    public Transform bulletSpawn; // nereden at�� yap�lacak
    public float bulletSpeed = 10f; // at�� h�z�
    public float fireInterval = 2f; // ate� aral���
   
    public Transform target; // hedef nesne

    private float fireTimer = 0f;

    private void Update()
    {
        // hedef nesnenin konumunu al
        Vector3 targetPosition = target.position;

        // boss karakterinin konumunu al
        Vector3 bossPosition = transform.position;

        // hedefe do�ru y�nelmek i�in y�n vekt�r�n� hesapla
        Vector3 direction = (targetPosition - bossPosition).normalized;

        // boss karakterini hedefe do�ru y�nlendir
        transform.right = direction;

        // ate� etmek i�in timer'� kontrol et
        if (fireTimer <= 0f)
        {
            Fire(); // ate� et
            fireTimer = fireInterval; // ate� aral���n� s�f�rla
        }
        else
        {
            fireTimer -= Time.deltaTime; // timer'� azalt
        }

        
    }

    private void Fire()
    {
        // at�� prefab'�ndan bir tane olu�tur
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // at�� h�z�n� ayarla
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = transform.right * bulletSpeed;

        Debug.Log("aaaa");

        // at�� prefab'�n� sil
        Destroy(bullet, 2f);
    }

    
}
