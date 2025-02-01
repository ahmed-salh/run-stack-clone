using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float smoothSpeed = 0.125f; 

    void FixedUpdate()
    {
        // TODO : remove the new key word for garbage collection optimization
        Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, target.position.z + offset.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
   }
}
