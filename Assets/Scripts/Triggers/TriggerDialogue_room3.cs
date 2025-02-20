using UnityEngine;
using System.Collections;

public class TriggerDialogue_room3 : MonoBehaviour
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

        for (int i = 0; i < dialogues.Length; i++)
        {
            if (dialogues[i] != null)
            {
                dialogues[i].SetActive(true);
                bool nextDialogue = false;
                float timer = 0f;

                while (timer < 8f && !nextDialogue)
                {
                    if (Input.GetKeyDown(KeyCode.Return)) // Skip to the next dialogue
                        nextDialogue = true;

                    timer += Time.deltaTime;
                    yield return null;
                }

                dialogues[i].SetActive(false);
            }
        }

        isInteracting = false; // Enable interactions again
    }
}
