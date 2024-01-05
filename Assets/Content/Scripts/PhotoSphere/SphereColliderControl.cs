using UnityEngine;

public class SphereColliderControl : MonoBehaviour
{
    private Collider sphereCollider;
    private Collider plutoSphereCollider;
    public GameObject InteractionAffordance;
    public GameObject PlutoSphere;

    void Start()
    {
        sphereCollider = GetComponent<Collider>();
        plutoSphereCollider = GetComponent<MeshCollider>();
    }

    // Call this method to disable the collider
    public void DisableCollider()
    {
        sphereCollider.enabled = false;
        plutoSphereCollider.enabled = false;
        
        InteractionAffordance.transform.gameObject.SetActive(false);
        PlutoSphere.transform.gameObject.SetActive(false);
    }

    // Call this method to enable the collider
    public void EnableCollider()
    {
        sphereCollider.enabled = true;
        plutoSphereCollider.enabled = true;

        InteractionAffordance.transform.gameObject.SetActive(true);
        PlutoSphere.transform.gameObject.SetActive(true);

    }
}
