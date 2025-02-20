using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinTrigger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    public Sprite newSprite; // Assign the new sprite in the Inspector
    public Sprite oldSprite;
    public GameObject[] dialogues; // Assign 6 dialogues in the Inspector
    private bool isInteracting = false;
    int count = 0;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ghost"))
        {
            ChangeSprite1();
            // Add dialog or any other functionality here
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ghost"))
        {
            if(Input.GetKeyDown(KeyCode.RightShift)) {
                if(count == 0) {
                    StartCoroutine(DisplayDialogues());
                    count++;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ghost"))
        {
            ChangeSprite2();
        }
    }

    void ChangeSprite1()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = newSprite; // Change to the new sprite
            Debug.Log("Sprite changed!");
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or newSprite not assigned!");
        }
    }

    void ChangeSprite2()
    {
        if (spriteRenderer != null && newSprite != null)
        {
            spriteRenderer.sprite = oldSprite; // Change to the new sprite
            Debug.Log("Sprite changed!");
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or newSprite not assigned!");
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
                while (timer < 2f && !nextDialogue)
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
