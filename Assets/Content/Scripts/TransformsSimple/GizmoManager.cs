using UnityEngine;
using UnityEngine.InputSystem;

public class GizmoManager : MonoBehaviour
{
    public GameObject transformGizmosParent;
    public GameObject rotateGizmosParent;
    public GameObject scaleGizmosParent;

    private InputAction transformAction;
    private InputAction rotateAction;
    private InputAction scaleAction;

    void Start()
    {
        // Set up input actions (assuming you have set these up in the Input System)
        transformAction = new InputAction(binding: "<Keyboard>/a");
        rotateAction = new InputAction(binding: "<Keyboard>/s");
        scaleAction = new InputAction(binding: "<Keyboard>/d");

        transformAction.performed += ctx => ActivateGizmos(transformGizmosParent);
        rotateAction.performed += ctx => ActivateGizmos(rotateGizmosParent);
        scaleAction.performed += ctx => ActivateGizmos(scaleGizmosParent);

        transformAction.Enable();
        rotateAction.Enable();
        scaleAction.Enable();
    }

    private void ActivateGizmos(GameObject gizmosParent)
    {
        transformGizmosParent.SetActive(false);
        rotateGizmosParent.SetActive(false);
        scaleGizmosParent.SetActive(false);

        gizmosParent.SetActive(true);
    }
}
