using UnityEngine;
using System.Collections;

public class TriggerDialogue_room2 : MonoBehaviour
{
    private int count = 0;
    public GameObject[] dialogues; // Assign 6 dialogues in the Inspector
    public MonoBehaviour ghostMovementScript; // Reference to the ghost's movement script
    public MonoBehaviour humanMovementScript; // Reference to the human's movement script
    public Rigidbody2D ghostRb; // Assign the Ghost's Rigidbody2D in Inspector
    public Rigidbody2D humanRb; // Assign the Human's Rigidbody2D in Inspector
    public Door door2; // Assign door in the Inspector

    private bool isInteracting = false;

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

        for (int i = 0; i < dialogues.Length; i++)
        {
            if (dialogues[i] != null)
            {
                dialogues[i].SetActive(true);
                bool nextDialogue = false;
                float timer = 0f;

                // Wait for 2 seconds or until Enter is pressed
                while (timer < 8f && !nextDialogue)
                {
                    if (Input.GetKeyDown(KeyCode.Return)) // Skip to the next dialogue
                        nextDialogue = true;

                    timer += Time.deltaTime;
                    yield return null;
                }

                dialogues[i].SetActive(false);

                // Open the door after the last dialogue (index 5)
                if (i == 1 && door2 != null)
                {
                    door2.PassDoor();
                }
            }
        }

        isInteracting = false; // Enable interactions again
    }
}
