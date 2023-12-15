using UnityEngine;

public class PlayerSphereController : MonoBehaviour
{
    public float activationDistance = 5f; // Distance threshold to enable/disable the collider
    private SphereColliderControl nearestSphereColliderControl;
    private GameObject[] spheres;

    void Start()
    {
        // Find all spheres in the game
        spheres = GameObject.FindGameObjectsWithTag("SphereTag");
    }

    void Update()
    {
        FindNearestSphere();
        CheckDistanceAndToggleCollider();
    }

    void FindNearestSphere()
    {
        float minDistance = float.MaxValue;
        GameObject nearestSphere = null;

        foreach (GameObject sphere in spheres)
        {
            float distance = Vector3.Distance(transform.position, sphere.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestSphere = sphere;
            }
        }

        if (nearestSphere != null)
        {
            nearestSphereColliderControl = nearestSphere.GetComponent<SphereColliderControl>();
        }
    }

    void CheckDistanceAndToggleCollider()
    {
        if (nearestSphereColliderControl == null) return;

        float distanceToNearestSphere = Vector3.Distance(transform.position, nearestSphereColliderControl.transform.position);

        if (distanceToNearestSphere < activationDistance)
        {
            nearestSphereColliderControl.DisableCollider();
        }
        else
        {
            nearestSphereColliderControl.EnableCollider();
        }
    }
}
