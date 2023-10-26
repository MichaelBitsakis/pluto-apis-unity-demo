using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CroquetReparenter : MonoBehaviour
{
    public Transform newParent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!newParent) 
        {
            Debug.Log("*** NEW PARENT DOES NOT EXIST");
            return;
        }

        foreach (var spawn in GameObject.FindGameObjectsWithTag("CroquetView"))
        {
            if (spawn.transform.parent) return;
            spawn.transform.parent = newParent;
        }
    }
}
