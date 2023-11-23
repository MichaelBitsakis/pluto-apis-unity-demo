using UnityEngine;

public class TranslateAxisManager : MonoBehaviour
{
    public GameObject axisX, axisY, axisZ, targetObject;
    public bool targetIsMoved = false;
    private Vector3 lastPosAxisX, lastPosAxisY, lastPosAxisZ;
    private Vector3 offsetAxisX, offsetAxisY, offsetAxisZ;

    void Start()
    {
        UpdateInitialPositions();
    }

    void LateUpdate()
    {
        if (targetIsMoved)
        {
            UpdateAxisPositionsRelativeToTarget();
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
        UpdateOffsets();
    }

    private void UpdateOffsets()
    {
        offsetAxisX = axisX.transform.position - targetObject.transform.position;
        offsetAxisY = axisY.transform.position - targetObject.transform.position;
        offsetAxisZ = axisZ.transform.position - targetObject.transform.position;
    }

    private void UpdateAxisPositionsRelativeToTarget()
    {
        axisX.transform.position = targetObject.transform.position + offsetAxisX;
        axisY.transform.position = targetObject.transform.position + offsetAxisY;
        axisZ.transform.position = targetObject.transform.position + offsetAxisZ;
    }

    private void CheckAndUpdateAxisMovement(GameObject axis, ref Vector3 lastAxisPos)
    {
        if (axis.transform.position != lastAxisPos)
        {
            Vector3 movementDelta = axis.transform.position - lastAxisPos;
            // Apply movement to the target object
            targetObject.transform.position += movementDelta;
            // Update all axis positions relative to the new target position
            UpdateAxisPositionsRelativeToTarget();
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
