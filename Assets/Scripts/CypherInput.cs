using UnityEngine;
using TMPro;

public class CypherInput : MonoBehaviour
{
    public TMP_InputField inputField; // Assign in Inspector
    public int correctCode = 351; // Set the correct number
    public Door door5;

    void Update()
    {
        // Check if Enter key is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ValidateCode();
            return;
        }
    }

    public void ValidateCode()
    {
        if (int.TryParse(inputField.text, out int enteredCode))
        {
            if (enteredCode == correctCode)
            {
                Debug.Log("Correct Code!");
                door5.PassDoor();
            }
            else
            {
                Debug.Log("Wrong Code!");
                inputField.text = ""; // Clear field for retry
            }
        }
        else
        {
            Debug.Log("Invalid Input! Enter a number.");
            inputField.text = ""; // Reset invalid input
        }
    }
}
