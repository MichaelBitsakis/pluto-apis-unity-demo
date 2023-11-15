using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class TransformGizmoController : MonoBehaviour
{
    public GizmoAxisController xAxisController;
    public GizmoAxisController yAxisController;
    public GizmoAxisController zAxisController;

    private GizmoAxisController activeController;
    private XRBaseInteractor activeInteractor;

    void Start()
    {
        // Initialize each axis controller with the target object
        // Assuming each axis controller has been assigned in the inspector
        // You could also find these dynamically if you prefer
    }

    public void OnGizmoSelectEntered(XRBaseInteractor interactor, GizmoAxisController selectedController)
    {
        activeController = selectedController;
        activeInteractor = interactor;
        activeController.OnSelectEntered(new SelectEnterEventArgs { interactable = activeController.interactable });
    }

    public void OnGizmoSelectExited(XRBaseInteractor interactor, GizmoAxisController selectedController)
    {
        if (activeController == selectedController)
        {
            activeController.OnSelectExited(new SelectExitEventArgs { interactable = activeController.interactable });
            activeController = null;
            activeInteractor = null;
        }
    }

    void Update()
    {
        if (activeController != null)
        {
            // Calculate the inputDelta based on controller movement
            Vector3 inputDelta = GetInputDelta();

            // Call the UpdateTransform method of the active axis controller
            activeController.UpdateTransform(inputDelta);
        }
    }

    private Vector3 GetInputDelta()
    {
        // Logic to calculate how much the controller has moved/rotated/scaled since last frame
        // This is a placeholder and should be replaced with actual input handling code
        Vector3 inputDelta = new Vector3(0, 0, 0); // Placeholder
        return inputDelta;
    }

    private Vector3 GetInputFromController(XRBaseInteractor interactor)
    {
        // This method should return the input from the XR controller
        // For example, this could be the change in position of the controller since the last frame
        // The actual implementation will depend on your input system and how you want to calculate the transformation
        return new Vector3(0, 0, 0); // Placeholder
    }

    // Call this method from the child gizmo controllers when they are selected
    public void SetActiveController(GizmoAxisController controller)
    {
        if (activeController != null)
        {
            activeController.OnSelectExited(new SelectExitEventArgs { interactable = activeController.interactable });
        }
        activeController = controller;
    }

    // Add any additional methods needed for handling interaction logic
}
