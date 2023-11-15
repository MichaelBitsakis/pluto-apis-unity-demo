using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GizmoAxisController : MonoBehaviour
{
    public enum Axis
    {
        X,
        Y,
        Z
    }

    public Axis axis;
    public Transform targetObject;
    public XRBaseInteractable interactable;
    public Color activeColor = Color.red;
    private Color originalColor;
    private Material gizmoMaterial;

    // Add these variables to indicate the type of gizmo
    public bool isMoveGizmo;
    public bool isRotateGizmo;
    public bool isScaleGizmo;

    void Start()
    {
        gizmoMaterial = GetComponent<Renderer>().material;
        originalColor = gizmoMaterial.color;

        interactable.selectEntered.AddListener(OnSelectEntered);
        interactable.selectExited.AddListener(OnSelectExited);
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        gizmoMaterial.color = activeColor;
        // Additional logic for when the gizmo is selected
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        gizmoMaterial.color = originalColor;
        // Additional logic for when the gizmo is deselected
    }

    public void UpdateTransform(Vector3 inputDelta)
    {
        // Depending on the gizmo type, apply the appropriate transformation
        switch (axis)
        {
            case Axis.X:
                // For translation gizmo, move the object along the X axis
                if (isMoveGizmo)
                    targetObject.position += transform.right * inputDelta.x;

                // For rotation gizmo, rotate the object around the X axis
                if (isRotateGizmo)
                    targetObject.Rotate(transform.right, inputDelta.x, Space.World);

                // For scale gizmo, scale the object along the X axis
                if (isScaleGizmo)
                    targetObject.localScale = new Vector3(targetObject.localScale.x + inputDelta.x, targetObject.localScale.y, targetObject.localScale.z);
                break;

            case Axis.Y:
                // Apply transformations for the Y axis...
                break;

            case Axis.Z:
                // Apply transformations for the Z axis...
                break;
        }
    }

    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelectEntered);
        interactable.selectExited.RemoveListener(OnSelectExited);
    }
}

