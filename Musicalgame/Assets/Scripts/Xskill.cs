using UnityEngine;

public class Xskill : MonoBehaviour
{
    public float fireRate = 60f; // Mermi atýþ hýzý (60 saniyede bir atýþ)
    private float nextFire = 0.0f; // Bir sonraki atýþ zamaný
    public Rigidbody2D bulletPrefab; // Mermi örneði
    public int numBullets = 4; // Toplam mermi sayýsý
    public float bulletSpeed = 10f; // Mermi hýzý

    void Update()
    {
        if (Time.time > nextFire && Input.GetKeyDown(KeyCode.X))
        {
            nextFire = Time.time + fireRate;

            // Toplam mermi sayýsýna göre mermi örnekleri oluþtur
            for (int i = 0; i < numBullets; i++)
            {
                Rigidbody2D bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse); // Mermiye hareket kuvveti uygula
                bullet.transform.rotation = Quaternion.AngleAxis(360f / numBullets * i, Vector3.forward); // Mermi yönünü hesapla

                // Her mermiye bir Collider2D bileþeni ekle
                CircleCollider2D bulletCollider = bullet.gameObject.AddComponent<CircleCollider2D>();

                // Mermi ömrünü sýnýrla
                Destroy(bullet.gameObject, 3f);
            }
        }
    }
}

