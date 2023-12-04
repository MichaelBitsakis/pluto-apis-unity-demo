using UnityEngine;
using System.Collections.Generic; // Required for using List

public class TranslateUIManager : MonoBehaviour
{
    public GameObject axisX, axisY, axisZ;
    public List<GameObject> targetObjects; // List of target objects
    public bool targetIsMoved = false;
    private Vector3 lastPosAxisX, lastPosAxisY, lastPosAxisZ;
    private Dictionary<GameObject, Vector3[]> offsets; // Dictionary to store offsets for each target object

    void Start()
    {
        offsets = new Dictionary<GameObject, Vector3[]>();
        UpdateInitialPositions();
        foreach (var target in targetObjects)
        {
            UpdateOffsets(target); // Initialize offsets for each target object
        }
    }

    void LateUpdate()
    {
        if (targetIsMoved)
        {
            foreach (var target in targetObjects)
            {
                UpdateAxisPositionsRelativeToTarget(target);
            }
        }
        else
        {
            // Check and update each axis' movement
            CheckAndUpdateAxisMovement(axisX, ref lastPosAxisX);
            CheckAndUpdateAxisMovement(axisY, ref lastPosAxisY);
            CheckAndUpdateAxisMovement(axisZ, ref lastPosAxisZ);
        }
    }

    private void UpdateInitialPositions()
    {
        lastPosAxisX = axisX.transform.position;
        lastPosAxisY = axisY.transform.position;
        lastPosAxisZ = axisZ.transform.position;
    }

    private void UpdateOffsets(GameObject targetObject)
    {
        Vector3[] targetOffsets = new Vector3[3];
        targetOffsets[0] = axisX.transform.position - targetObject.transform.position;
        targetOffsets[1] = axisY.transform.position - targetObject.transform.position;
        targetOffsets[2] = axisZ.transform.position - targetObject.transform.position;
        offsets[targetObject] = targetOffsets;
    }

    private void UpdateAxisPositionsRelativeToTarget(GameObject targetObject)
    {
        Vector3[] targetOffsets = offsets[targetObject];
        axisX.transform.position = targetObject.transform.position + targetOffsets[0];
        axisY.transform.position = targetObject.transform.position + targetOffsets[1];
        axisZ.transform.position = targetObject.transform.position + targetOffsets[2];
    }

    private void CheckAndUpdateAxisMovement(GameObject axis, ref Vector3 lastAxisPos)
    {
        if (axis.transform.position != lastAxisPos)
        {
            Vector3 movementDelta = axis.transform.position - lastAxisPos;
            foreach (var target in targetObjects)
            {
                // Apply movement to each target object
                target.transform.position += movementDelta;
                // Update axis positions relative to the new target position
                UpdateAxisPositionsRelativeToTarget(target);
                // Update offsets for the moved target
                UpdateOffsets(target);
            }
            // Update last known positions
            UpdateInitialPositions();
        }
    }

    public void SetTargetMovementOn()
    {
        targetIsMoved = true;
    }

    public void SetTargetMovementOff()
    {
        targetIsMoved = false;
    }
}
