using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bulletPrefab; // atýþ prefab'ý
    public Transform bulletSpawn; // nereden atýþ yapýlacak
    public float bulletSpeed = 10f; // atýþ hýzý
    public float fireInterval = 2f; // ateþ aralýðý
   
    public Transform target; // hedef nesne

    private float fireTimer = 0f;

    private void Update()
    {
        // hedef nesnenin konumunu al
        Vector3 targetPosition = target.position;

        // boss karakterinin konumunu al
        Vector3 bossPosition = transform.position;

        // hedefe doðru yönelmek için yön vektörünü hesapla
        Vector3 direction = (targetPosition - bossPosition).normalized;

        // boss karakterini hedefe doðru yönlendir
        transform.right = direction;

        // ateþ etmek için timer'ý kontrol et
        if (fireTimer <= 0f)
        {
            Fire(); // ateþ et
            fireTimer = fireInterval; // ateþ aralýðýný sýfýrla
        }
        else
        {
            fireTimer -= Time.deltaTime; // timer'ý azalt
        }

        
    }

    private void Fire()
    {
        // atýþ prefab'ýndan bir tane oluþtur
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // atýþ hýzýný ayarla
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = transform.right * bulletSpeed;

        Debug.Log("aaaa");

        // atýþ prefab'ýný sil
        Destroy(bullet, 2f);
    }

    
}
