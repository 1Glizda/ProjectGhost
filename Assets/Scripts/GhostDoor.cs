using UnityEngine;

public class GhostDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object has the "Player" tag
        if (other.CompareTag("Ghost"))
        {
            Debug.Log("Ghost entered the door. Allowing passage.");
        }
            else
            {
                // BlockHuman(other.gameObject);
            }
    }

    private void BlockHuman(GameObject human)
    {
        human.transform.position = transform.position - new Vector3(1, 0, 0); // Move them back slightly
    }
}