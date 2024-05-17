
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /* public GameObject targetObject; // kameray� takip etmesini istedi�im objeye referans verdik
     public Vector3 cameraOffset; // bunu yazmay�na player�n i�ine giriyor biraz uza�a almak i�in z sini -10 ald�k
     public Vector3 targetedPosition;
     public Vector3 velocity = Vector3.zero;

     public float smoothTime = 0.3F;
     void LateUpdate()
     {
         targetedPosition = targetObject.transform.position + cameraOffset; // targetedPosition dedi�im kamera objesinin i�inde scrpit old. i�in o oluyor
         transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
     }
    */

    public Transform target;  // Takip edilecek obje (genellikle player)
    public float smoothSpeed = 0.3f;  // Kamera hareketinin yumu�akl���
    public Vector3 offset;  // Kamera ve takip edilen obje aras�ndaki mesafe

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

        // Kameran�n sahneden d��ar� ta�mas�n� engelle
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    // Min ve max de�erlerini ayarlay�n
    float minX = -38f;
    float maxX = 18f;
    float minY = -5f;
    float maxY = 0f;
}
