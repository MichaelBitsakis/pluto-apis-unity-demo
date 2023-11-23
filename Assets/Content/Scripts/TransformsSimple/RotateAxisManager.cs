using UnityEngine;

public class RotateAxisManager : MonoBehaviour
{
    public GameObject axisX, axisY, axisZ, targetObject;
    public bool targetIsRotated = false;
    private Quaternion lastRotAxisX, lastRotAxisY, lastRotAxisZ;
    private Vector3 offsetAxisX, offsetAxisY, offsetAxisZ;

    void Start()
    {
        UpdateInitialRotations();
        UpdateOffsets();
    }

    void LateUpdate()
    {
        

        if (targetIsRotated)
        {
            // Update axis positions relative to the target
            UpdateAxisPositionsRelativeToTarget();
        }
        else
        {   // Check and update each axis' rotation
            CheckAndUpdateAxisRotation(axisX, ref lastRotAxisX, Vector3.right);
            CheckAndUpdateAxisRotation(axisY, ref lastRotAxisY, Vector3.up);
            CheckAndUpdateAxisRotation(axisZ, ref lastRotAxisZ, Vector3.forward);

        }
    }

    private void UpdateInitialRotations()
    {
        lastRotAxisX = axisX.transform.rotation;
        lastRotAxisY = axisY.transform.rotation;
        lastRotAxisZ = axisZ.transform.rotation;
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

    private void CheckAndUpdateAxisRotation(GameObject axis, ref Quaternion lastAxisRot, Vector3 rotationAxis)
    {
        if (axis.transform.rotation != lastAxisRot)
        {
            Quaternion rotationDelta = axis.transform.rotation * Quaternion.Inverse(lastAxisRot);
            targetObject.transform.Rotate(rotationAxis, rotationDelta.eulerAngles.magnitude, Space.World);
            lastAxisRot = axis.transform.rotation;

            // Update axis positions as the target might have moved
            UpdateOffsets();
            UpdateAxisPositionsRelativeToTarget();
        }
    }

    public void SetTargetRotationOn()
    {
        targetIsRotated = true;
    }

    public void SetTargetRotationOff()
    {
        targetIsRotated = false;
    }
}
