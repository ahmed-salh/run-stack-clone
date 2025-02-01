using System;
using UnityEngine;

public class CollisionEventsHandler : MonoBehaviour
{
    private StackController _stackController;

    public static event Action<Transform> onCollected;

    public static event Action<Transform> onHitObstacle;


    private void Awake()
    {
        _stackController = GetComponentInChildren<StackController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            onCollected?.Invoke(collision.transform);
            
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            onHitObstacle?.Invoke(collision.transform);

            collision.collider.enabled = false;
        }
    }

}
