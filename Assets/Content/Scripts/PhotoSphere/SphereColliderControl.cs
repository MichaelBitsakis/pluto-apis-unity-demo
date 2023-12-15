using UnityEngine;

public class SphereColliderControl : MonoBehaviour
{
    private Collider sphereCollider;
    public GameObject InteractionAffordance;

    void Start()
    {
        sphereCollider = GetComponent<Collider>();
    }

    // Call this method to disable the collider
    public void DisableCollider()
    {
        sphereCollider.enabled = false;
        InteractionAffordance.transform.gameObject.SetActive(false);
    }

    // Call this method to enable the collider
    public void EnableCollider()
    {
        sphereCollider.enabled = true;
        InteractionAffordance.transform.gameObject.SetActive(true);

    }
}
