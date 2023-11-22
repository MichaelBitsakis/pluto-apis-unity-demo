using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GizmoPerAxisController : MonoBehaviour
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

    [SerializeField] private bool isDebug;

    // Add these variables to indicate the type of gizmo
    public bool isMoveGizmo;
    public bool isRotateGizmo;
    public bool isScaleGizmo;

    // Start is called before the first frame update
    void Start()
    {
        gizmoMaterial = GetComponent<Renderer>().material;
        originalColor = gizmoMaterial.color;

        interactable.selectEntered.AddListener(OnSelectEntered);
        interactable.selectExited.AddListener(OnSelectExited);
    }

    public void Update()
    {
        // Depending on the gizmo type, apply the appropriate transformation
        switch (axis)
        {
            
            case Axis.X:
                // For translation gizmo, move the object along the X axis
                if (isMoveGizmo)
                    targetObject.position += transform.right;
               
                else
                    Debug.Log("");
                break;
                
            case Axis.Y:
                // For translation gizmo, move the object along the Y axis
                if (isMoveGizmo)
                    targetObject.position += transform.up;
                
                break;
                
            case Axis.Z:
                // For translation gizmo, move the object along the Z axis
                if (isMoveGizmo)                    
                    targetObject.position += transform.up;
                else
                    Debug.Log("");
                break;
                                
        }

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

    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelectEntered);
        interactable.selectExited.RemoveListener(OnSelectExited);
    }
}
