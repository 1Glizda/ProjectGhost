using UnityEngine;

public class CandleTrigger : MonoBehaviour
{
    // The amount of pixels to move in each direction (X, Y, Z)
    public Vector3 moveOffset;

    // The speed at which the object moves
    public float moveSpeed = 5f;

    // Flag to check if the object should move
    private bool shouldMove = false;

    // The original position of the object
    private Vector3 originalPosition;

    // The target position calculated from the original position and the moveOffset
    private Vector3 targetPosition;

    void Start()
    {
        // Store the original position of the object
        originalPosition = transform.position;

        // Calculate the target position based on the original position and the moveOffset
        targetPosition = originalPosition + moveOffset;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player enters the trigger and presses RightShift
        if (other.CompareTag("Ghost") && Input.GetKey(KeyCode.RightShift))
        {
            shouldMove = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Check if the player is inside the trigger and presses RightShift
        if (other.CompareTag("Ghost") && Input.GetKey(KeyCode.RightShift))
        {
            shouldMove = true;
        }
    }

    void Update()
    {
        // Move the object towards the target position if shouldMove is true
        if (shouldMove)
        {
            MoveToTargetPosition();
        }
    }

    void MoveToTargetPosition()
    {
        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Stop moving if the object reaches the target position
        if (transform.position == targetPosition)
        {
            shouldMove = false;
        }
    }
}