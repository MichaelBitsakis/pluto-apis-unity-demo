using UnityEngine;
using TMPro; // Namespace for TextMesh Pro
using UnityEngine.UI; // Namespace for UI components

public class NameToUI : MonoBehaviour
{
    public GameObject targetObject; // The object whose name you want to display
    public bool isButton = false; // Flag to determine if the text is part of a button
    public TextMeshProUGUI textMeshObject; // The TextMeshPro object to display the name
    public Button button; // The Button whose text you want to set

    void Update()
    {
        if (targetObject != null)
        {
            if (isButton && button != null)
            {
                // Set the text of the Button's TextMeshPro component
                TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    buttonText.text = targetObject.name;
                }
            }
            else if (textMeshObject != null)
            {
                // Set the text of the standalone TextMeshPro object
                textMeshObject.text = targetObject.name;
            }
        }
    }
}
