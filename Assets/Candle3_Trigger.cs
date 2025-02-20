using UnityEngine;

public class Candle3_Trigger : MonoBehaviour
{
    // The target position to move the object to
    public Vector3 targetPosition;

    // The speed at which the object moves
    public float moveSpeed = 5f;

    // Flag to check if the object should move
    private bool shouldMove = false;

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