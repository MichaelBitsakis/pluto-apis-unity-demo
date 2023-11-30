using UnityEngine;
using UnityEngine.UI;
using TMPro; // Namespace for TextMesh Pro

public class ToggleButtonAndObjects : MonoBehaviour
{
    public TextMeshProUGUI buttonText; // Reference to the TextMeshProUGUI component on the button
    public string textWhenActive = "Close"; // Text to display when the objects are active
    public string textWhenInactive = "Open"; // Text to display when the objects are inactive
    public GameObject[] objectsToToggle; // Array of objects to toggle

    private bool areObjectsActive = false; // Current state of the objects

    public void ToggleObjectsAndText()
    {
        // Toggle the active state of each object
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }

        // Update the button text based on the new state
        UpdateButtonText();

        // Toggle the state flag
        areObjectsActive = !areObjectsActive;
    }

    private void UpdateButtonText()
    {
        if (buttonText != null)
        {
            buttonText.text = areObjectsActive ? textWhenInactive : textWhenActive;
        }
    }
}
