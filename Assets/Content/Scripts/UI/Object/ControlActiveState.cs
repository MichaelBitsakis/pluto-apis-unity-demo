using UnityEngine;
using System.Collections.Generic;

public class ControlActiveState : MonoBehaviour
{
    public List<GameObject> openItems; // List of items to activate
    public List<GameObject> closeItems; // List of items to deactivate
    public bool close = false;
    public bool open = false;

    public void Control()
    {
        if (close)
        {
            SetActiveStateOfItems(closeItems, false);
            //close = false; // Reset the flag
        }
        if (open)
        {
            SetActiveStateOfItems(openItems, true);
            //open = false; // Reset the flag
        }
    }

    private void SetActiveStateOfItems(List<GameObject> items, bool state)
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
