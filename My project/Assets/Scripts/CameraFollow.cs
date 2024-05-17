
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /* public GameObject targetObject; // kamerayý takip etmesini istediðim objeye referans verdik
     public Vector3 cameraOffset; // bunu yazmayýna playerýn içine giriyor biraz uzaða almak için z sini -10 aldýk
     public Vector3 targetedPosition;
     public Vector3 velocity = Vector3.zero;

     public float smoothTime = 0.3F;
     void LateUpdate()
     {
         targetedPosition = targetObject.transform.position + cameraOffset; // targetedPosition dediðim kamera objesinin içinde scrpit old. için o oluyor
         transform.position = Vector3.SmoothDamp(transform.position, targetedPosition, ref velocity, smoothTime);
     }
    */

    public Transform target;  // Takip edilecek obje (genellikle player)
    public float smoothSpeed = 0.3f;  // Kamera hareketinin yumuþaklýðý
    public Vector3 offset;  // Kamera ve takip edilen obje arasýndaki mesafe

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

        // Kameranýn sahneden dýþarý taþmasýný engelle
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    // Min ve max deðerlerini ayarlayýn
    float minX = -38f;
    float maxX = 18f;
    float minY = -5f;
    float maxY = 0f;
}
