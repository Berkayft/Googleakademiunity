using UnityEngine;

public class Xskill : MonoBehaviour
{
    public float fireRate = 60f; // Mermi at�� h�z� (60 saniyede bir at��)
    private float nextFire = 0.0f; // Bir sonraki at�� zaman�
    public Rigidbody2D bulletPrefab; // Mermi �rne�i
    public int numBullets = 4; // Toplam mermi say�s�
    public float bulletSpeed = 10f; // Mermi h�z�

    void Update()
    {
        if (Time.time > nextFire && Input.GetKeyDown(KeyCode.X))
        {
            nextFire = Time.time + fireRate;

            // Toplam mermi say�s�na g�re mermi �rnekleri olu�tur
            for (int i = 0; i < numBullets; i++)
            {
                Rigidbody2D bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse); // Mermiye hareket kuvveti uygula
                bullet.transform.rotation = Quaternion.AngleAxis(360f / numBullets * i, Vector3.forward); // Mermi y�n�n� hesapla

                // Her mermiye bir Collider2D bile�eni ekle
                CircleCollider2D bulletCollider = bullet.gameObject.AddComponent<CircleCollider2D>();

                // Mermi �mr�n� s�n�rla
                Destroy(bullet.gameObject, 3f);
            }
        }
    }
}

