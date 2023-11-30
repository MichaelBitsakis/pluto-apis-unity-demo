using UnityEngine;
using System.Collections.Generic;

public class ControlActiveState : MonoBehaviour
{
    public List<GameObject> items; // List of items to control
    public bool close = false;
    public bool open = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Control()
    {
        if (close)
        {
            SetActiveStateOfItems(false);
            close = false; // Reset the flag
        }
        else if (open)
        {
            SetActiveStateOfItems(true);
            open = false; // Reset the flag
        }
    }

    private void SetActiveStateOfItems(bool state)
    {
        foreach (var item in items)
        {
            if (item != null)
            {
                item.SetActive(state);
            }
        }
    }
}
