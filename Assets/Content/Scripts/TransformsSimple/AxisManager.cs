using UnityEngine;

public class AxisManager : MonoBehaviour
{
    public GameObject axisX, axisY, axisZ, fourthObject;
    private Vector3 lastPosX, lastPosY, lastPosZ;

    void Start()
    {
        // Initialize the last positions
        lastPosX = axisX.transform.position;
        lastPosY = axisY.transform.position;
        lastPosZ = axisZ.transform.position;
    }

    void LateUpdate()
    {
        // Check for movement in Axis X
        if (axisX.transform.position != lastPosX)
        {
            Vector3 movement = axisX.transform.position - lastPosX;
            UpdatePositions(movement, axisX);
            lastPosX = axisX.transform.position;
        }

        // Check for movement in Axis Y
        if (axisY.transform.position != lastPosY)
        {
            Vector3 movement = axisY.transform.position - lastPosY;
            UpdatePositions(movement, axisY);
            lastPosY = axisY.transform.position;
        }

        // Check for movement in Axis Z
        if (axisZ.transform.position != lastPosZ)
        {
            Vector3 movement = axisZ.transform.position - lastPosZ;
            UpdatePositions(movement, axisZ);
            lastPosZ = axisZ.transform.position;
        }
    }

    private void UpdatePositions(Vector3 movement, GameObject movedAxis)
    {
        // Restrict movement to the specific axis
        if (movedAxis == axisX)
            movement = new Vector3(movement.x, 0, 0);
        else if (movedAxis == axisY)
            movement = new Vector3(0, movement.y, 0);
        else if (movedAxis == axisZ)
            movement = new Vector3(0, 0, movement.z);

        // Update positions of other axes and the fourth object
        if (movedAxis != axisX)
            axisX.transform.position += movement;
        if (movedAxis != axisY)
            axisY.transform.position += movement;
        if (movedAxis != axisZ)
            axisZ.transform.position += movement;

        fourthObject.transform.position += movement;
    }
}
