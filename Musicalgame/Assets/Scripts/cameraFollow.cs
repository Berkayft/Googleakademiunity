using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        // Hedef konumunu hesaplar
        Vector3 desiredPosition = target.position + offset;

        // Hedef konuma doðru yumuþak bir þekilde hareket eder
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Kamera konumunu ayarlar
        transform.position = smoothedPosition;
    }
}

