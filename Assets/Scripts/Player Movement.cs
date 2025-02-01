using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool canMove = false;

    [SerializeField]
    private float forwardSpeed = 2f;
    
    [SerializeField]
    private float sideSpeed = 5f;

    private Rigidbody rigidBody;

    private void OnEnable()
    {
        CollisionEventsHandler.onHitObstacle += MoveUp;
        GameplayEventsHandeler.GameStarted += StartMoving;
    }

    private void OnDisable()
    {
        CollisionEventsHandler.onHitObstacle -= MoveUp;
        GameplayEventsHandeler.GameStarted -= StartMoving;

    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rigidBody.MovePosition(transform.position + forwardSpeed * Time.fixedDeltaTime * transform.forward 
                + sideSpeed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime * transform.right);
        }
    }

    private void MoveUp(Transform other) 
    {
        var obstaclesController = other.transform.GetComponent<ObstacleStackController>();

        transform.position += (other.transform.childCount * (obstaclesController.spacing + obstaclesController.height) * transform.up);
    }

    private void StartMoving() 
    {
        if (!canMove) 
        {
            GetComponentInChildren<Actor>().UpdateAnimation("Run");
            canMove = true;
        }
    }
}
