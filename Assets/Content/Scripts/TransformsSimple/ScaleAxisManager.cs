using UnityEngine;

public class ScaleAxisManager : MonoBehaviour
{
    public GameObject axisX, axisY, axisZ, targetObject;
    public bool targetIsScaled = false;
    private Vector3 lastPosAxisX, lastPosAxisY, lastPosAxisZ;
    private Vector3 initialScale;

    void Start()
    {
        UpdateInitialPositions();
        initialScale = targetObject.transform.localScale;
    }

    void LateUpdate()
    {
        if (targetIsScaled)
        {
            // Update axis positions relative to the target
            UpdateAxisPositionsRelativeToTarget();
        }
        else
        {
            // Check and update each axis' position for scaling
            CheckAndUpdateAxisScaling(axisX, ref lastPosAxisX, Vector3.right);
            CheckAndUpdateAxisScaling(axisY, ref lastPosAxisY, Vector3.up);
            CheckAndUpdateAxisScaling(axisZ, ref lastPosAxisZ, Vector3.forward);
        }
    }

    private void UpdateInitialPositions()
    {
        lastPosAxisX = axisX.transform.position;
        lastPosAxisY = axisY.transform.position;
        lastPosAxisZ = axisZ.transform.position;
    }

    private void UpdateAxisPositionsRelativeToTarget()
    {
        axisX.transform.position = targetObject.transform.position + targetObject.transform.localScale.x * Vector3.right;
        axisY.transform.position = targetObject.transform.position + targetObject.transform.localScale.y * Vector3.up;
        axisZ.transform.position = targetObject.transform.position + targetObject.transform.localScale.z * Vector3.forward;
    }

    private void CheckAndUpdateAxisScaling(GameObject axis, ref Vector3 lastAxisPos, Vector3 scaleDirection)
    {
        Vector3 positionDelta = axis.transform.position - lastAxisPos;
        if (positionDelta != Vector3.zero)
        {
            float scaleChange = positionDelta.magnitude * Mathf.Sign(Vector3.Dot(positionDelta, scaleDirection));
            Vector3 newScale = targetObject.transform.localScale;
            newScale += scaleDirection * scaleChange;
            targetObject.transform.localScale = newScale;

            // Update the initial positions to the new positions
            UpdateInitialPositions();

            // Update axis positions as the target might have scaled
            UpdateAxisPositionsRelativeToTarget();
        }
    }

    public void SetTargetScaleOn()
    {
        targetIsScaled = true;
    }

    public void SetTargetScaleOff()
    {
        targetIsScaled = false;
    }
}
