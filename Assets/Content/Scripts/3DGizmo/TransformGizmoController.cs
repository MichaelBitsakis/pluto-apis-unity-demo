using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class TransformGizmoController : MonoBehaviour
{
    public GizmoAxisController xAxisController;
    public GizmoAxisController yAxisController;
    public GizmoAxisController zAxisController;


    [SerializeField] private bool isDebug;

    private GizmoAxisController activeController;
    private XRBaseInteractor activeInteractor;

    private Vector3 lastInteractorPosition;

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

            if (isDebug)
            {
                Debug.Log($"Update called with inputDelta {inputDelta}");
            }
            

            // Call the UpdateTransform method of the active axis controller
            activeController.UpdateTransform(inputDelta);
        }
    }

    private Vector3 GetInputDelta()
    {
        if (activeInteractor == null) return Vector3.zero;

        Vector3 currentInteractorPosition = activeInteractor.transform.position;
        Vector3 positionDelta = currentInteractorPosition - lastInteractorPosition;
        lastInteractorPosition = currentInteractorPosition; // Update for next frame

        // Convert the global position delta to a local space delta to apply to the target object
        Vector3 localDelta = transform.InverseTransformDirection(positionDelta);

        return localDelta;
    }

    private Vector3 GetInputFromController(XRBaseInteractor interactor)
    {
        if (interactor == null) return Vector3.zero;

        // Example: Calculate the change in position of the controller
        Vector3 currentInteractorPosition = interactor.transform.position;
        Vector3 positionDelta = currentInteractorPosition - lastInteractorPosition;
        lastInteractorPosition = currentInteractorPosition; // Update for the next frame

        // Depending on your gizmo's orientation and the desired behavior, 
        // you might need to adjust the delta here.
        // For instance, you might only be interested in the movement along certain axes,
        // or you might want to scale the delta by some factor.

        return positionDelta;
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
