using UnityEngine;
using System.Collections.Generic;

public class DoorSequenceManager : MonoBehaviour
{
    public List<Door> doorSequence = new List<Door>();
    public List<GameObject> objectSequence = new List<GameObject>();

    private int currentIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ProcessNextStep();
        }
    }

    private void ProcessNextStep()
    {
        // Determine the longer list's length
        int maxLength = Mathf.Max(doorSequence.Count, objectSequence.Count);

        // Check if we've reached the end of the longer list
        if (currentIndex >= maxLength)
        {
            Debug.Log("Sequence complete!");
            return;
        }

        // Activate door (if it exists at this index)
        if (currentIndex < doorSequence.Count && doorSequence[currentIndex] != null)
        {
            doorSequence[currentIndex].PassDoor();
            Debug.Log($"Activated door: {doorSequence[currentIndex].name}");
        }

        // Activate GameObject (if it exists at this index)
        if (currentIndex < objectSequence.Count && objectSequence[currentIndex] != null)
        {
            objectSequence[currentIndex].SetActive(true);
            Debug.Log($"Activated object: {objectSequence[currentIndex].name}");
        }

        currentIndex++;
    }

    public void ResetSequence()
    {
        currentIndex = 0;
        foreach (GameObject obj in objectSequence)
        {
            if (obj != null) obj.SetActive(false);
        }
        Debug.Log("Sequence reset");
    }
}