using UnityEngine;
using System.Collections;

public class TriggerDialogue_room1 : MonoBehaviour
{
    private int count = 0;
    public GameObject[] dialogues; // Assign 6 dialogues in the Inspector
    public GameObject ghost; // Assign the Ghost GameObject in the Inspector
    public MonoBehaviour ghostMovementScript; // Reference to the ghost's movement script
    public MonoBehaviour humanMovementScript; // Reference to the human's movement script
    public Door door1; // Assign door in the Inspector

    private bool isInteracting = false;

    void Start()
    {
        if (ghost != null)
            ghost.SetActive(false); // Ensure Ghost starts inactive
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isInteracting && count == 0)
        {
            StartCoroutine(DisplayDialogues());
            count++;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!isInteracting && count == 0)
        {
            StartCoroutine(DisplayDialogues());
            count++;
        }
    }

    IEnumerator DisplayDialogues()
    {
        isInteracting = true; // Prevent multiple triggers

        // Disable player movement
        if (humanMovementScript != null) humanMovementScript.enabled = false;
        if (ghostMovementScript != null) ghostMovementScript.enabled = false;

        for (int i = 0; i < dialogues.Length; i++)
        {
            if (dialogues[i] != null)
            {
                dialogues[i].SetActive(true);
                bool nextDialogue = false;
                float timer = 0f;

                // Wait for 2 seconds or until Enter is pressed
                while (timer < 2f && !nextDialogue)
                {
                    if (Input.GetKeyDown(KeyCode.Return)) // Skip to the next dialogue
                        nextDialogue = true;

                    timer += Time.deltaTime;
                    yield return null;
                }

                dialogues[i].SetActive(false);

                // Activate Ghost after the 3rd dialogue (index 2)
                if (i == 2 && ghost != null)
                {
                    ghost.SetActive(true);
                }

                // Open the door after the last dialogue (index 5)
                if (i == 5 && door1 != null)
                {
                    door1.PassDoor();
                }
            }
        }

        // Re-enable player movement after dialogues finish
        if (humanMovementScript != null) humanMovementScript.enabled = true;
        if (ghostMovementScript != null) ghostMovementScript.enabled = true;

        isInteracting = false; // Enable interactions again
    }
}
