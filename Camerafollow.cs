using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    public float smoothSpeed = 0.125f;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(player);
    }
}