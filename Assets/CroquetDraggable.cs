using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CroquetDraggable : MonoBehaviour
{
    private bool tharBeDraggin = false;
    private int croquetHandle;

    CroquetSpatialComponent croquetSpatialComponent;
    CroquetSpatialSystem croquetSpatialSystem;

    // Start is called before the first frame update
    void Start()
    {
        croquetHandle = gameObject.GetComponent<CroquetEntityComponent>().croquetHandle;
        croquetSpatialComponent = gameObject.GetComponent<CroquetSpatialComponent>();
        croquetSpatialSystem = GameObject.FindFirstObjectByType<CroquetBridge>().GetComponent<CroquetSpatialSystem>();

        XRGrabInteractable grabby = GetComponent<XRGrabInteractable>();
        grabby.selectEntered.AddListener(handleXRSelect);
        grabby.selectExited.AddListener(handleXRDeselect);
    }

    // Update is called once per frame
    void Update()
    {
        if (tharBeDraggin)
        {
            // croquetSpatialSystem.GetComponents().Add(croquetSpatialComponent.gameObject.GetInstanceID(), croquetSpatialComponent);
            // croquetSpatialSystem.SnapObjectTo(croquetHandle, transform.position, transform.rotation, transform.localScale);
            // croquetSpatialSystem.SnapObjectInCroquet(croquetHandle, transform.position, transform.rotation, transform.localScale);
            // croquetSpatialSystem.GetComponents().Remove(croquetSpatialComponent.gameObject.GetInstanceID());
            croquetSpatialSystem.SnapObjectInCroquet(croquetHandle, transform.localPosition, transform.localRotation, transform.localScale);
            croquetSpatialComponent.position = transform.localPosition;
            croquetSpatialComponent.rotation.eulerAngles = transform.localEulerAngles;
        }
    }

    void handleXRSelect(SelectEnterEventArgs args)
    {
        if (!croquetSpatialComponent) return;
        if (!croquetSpatialSystem) return;

        Debug.Log($"XRSELECT :: Trying to remove {croquetSpatialComponent.gameObject.GetInstanceID()}");
        croquetSpatialSystem.GetComponents().Remove(croquetSpatialComponent.gameObject.GetInstanceID());
        tharBeDraggin= true;
    }

    void handleXRDeselect(SelectExitEventArgs args)
    {
        if (!croquetSpatialComponent) return;
        if (!croquetSpatialSystem) return;

        Debug.Log($"XRDESELECTS :: Trying to re-add {croquetSpatialComponent.gameObject.GetInstanceID()}");

        croquetSpatialSystem.GetComponents().Add(croquetSpatialComponent.gameObject.GetInstanceID(), croquetSpatialComponent);
        tharBeDraggin = false;
    }
}
