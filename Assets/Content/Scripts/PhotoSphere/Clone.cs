using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public GameObject prefabToClone;

    public void ClonePrefab()
    {
        Instantiate(prefabToClone, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
