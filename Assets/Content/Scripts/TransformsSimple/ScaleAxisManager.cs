using UnityEngine;

public class ScaleAxisManager : MonoBehaviour
{
    public GameObject axisX, axisY, axisZ, axisAll, targetObject; // Declare the axis GameObjects and the target object
    public bool targetIsScaled = false;
    public float scaleMultiplier = 1.0f; // Multiplier for scaling effect
    private Vector3 initialPosAxisX, initialPosAxisY, initialPosAxisZ, initialPosAxisAll; // Store the initial positions of the axes
    private Vector3 initialScale; // Store the initial scale of the target object

    void Start()
    {
        // Store the initial positions of the axis objects
        initialPosAxisX = axisX.transform.position;
        initialPosAxisY = axisY.transform.position;
        initialPosAxisZ = axisZ.transform.position;
        initialPosAxisAll = axisAll.transform.position; // Store the initial position for the uniform scaling axis

        // Store the initial scale of the target object
        initialScale = targetObject.transform.localScale;
    }

    void LateUpdate()
    {
        if (!targetIsScaled)
        {
            // Check and update each axis' position for scaling
            CheckAndUpdateAxisScaling(axisX, initialPosAxisX, Vector3.right);
            CheckAndUpdateAxisScaling(axisY, initialPosAxisY, Vector3.up);
            CheckAndUpdateAxisScaling(axisZ, initialPosAxisZ, Vector3.forward);

            // Check and update the uniform scaling axis
            CheckAndUpdateUniformScaling();
        }
    }

    private void CheckAndUpdateAxisScaling(GameObject axis, Vector3 initialAxisPos, Vector3 scaleDirection)
    {
        Vector3 positionDelta = axis.transform.position - initialAxisPos;
        if (positionDelta != Vector3.zero)
        {
            float scaleChange = positionDelta.magnitude * Mathf.Sign(Vector3.Dot(positionDelta, scaleDirection)) * scaleMultiplier;
            // Apply scale change only in the direction of the axis
            Vector3 scaleAdjustment = scaleDirection * scaleChange;
            Vector3 newScale = new Vector3(
                scaleDirection.x != 0 ? initialScale.x + scaleAdjustment.x : targetObject.transform.localScale.x,
                scaleDirection.y != 0 ? initialScale.y + scaleAdjustment.y : targetObject.transform.localScale.y,
                scaleDirection.z != 0 ? initialScale.z + scaleAdjustment.z : targetObject.transform.localScale.z
            );
            targetObject.transform.localScale = newScale;

            // Update initial scale to new scale
            initialScale = newScale;

            // Reset axis to initial position
            axis.transform.position = initialAxisPos;
        }
    }

    private void CheckAndUpdateUniformScaling()
    {
        Vector3 positionDelta = axisAll.transform.position - initialPosAxisAll;
        if (positionDelta != Vector3.zero)
        {
            float scaleChange = positionDelta.magnitude * scaleMultiplier;
            Vector3 newScale = initialScale + new Vector3(scaleChange, scaleChange, scaleChange);
            targetObject.transform.localScale = newScale;

            // Update initial scale to new scale
            initialScale = newScale;

            // Reset axisAll to its initial position after scaling
            axisAll.transform.position = initialPosAxisAll;
        }
    }

    public void SetTargetScaleOn()
    {
        targetIsScaled = true;
    }

    public void SetTargetScaleOff()
    {
        targetIsScaled = false;
        // Optionally, you could update initialScale here if you want to keep the changes only after scaling is turned off
        initialScale = targetObject.transform.localScale;
    }
}
