using UnityEngine;

public class CypherTrigger : MonoBehaviour
{
    public GameObject cypherUI; // Assign in the Inspector
    public GameObject inputHandler;

    void Start()
    {
        // If not assigned in the Inspector, try finding the Cypher GameObject
        if (cypherUI == null)
        {
            cypherUI = GameObject.Find("Cypher");
        }

        // Make sure it's initially disabled
        if (cypherUI != null)
        {
            cypherUI.SetActive(false);
            inputHandler.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            ActivateCypher();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            ActivateCypher();
        }
    }

    void ActivateCypher()
    {
        if (cypherUI != null)
        {
            cypherUI.SetActive(true);
            inputHandler.SetActive(true);
            Debug.Log("Cypher activated!");
        }
        else
        {
            Debug.LogWarning("Cypher GameObject not found!");
        }
    }
}
