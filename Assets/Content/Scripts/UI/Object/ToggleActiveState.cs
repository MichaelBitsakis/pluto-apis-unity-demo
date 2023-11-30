using UnityEngine;

public class ToggleActiveState : MonoBehaviour
{
    // Function to toggle the active state of the GameObject
    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
