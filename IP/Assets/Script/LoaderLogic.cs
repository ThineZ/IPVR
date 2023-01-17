using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class LoaderLogic : MonoBehaviour
{
    [SerializeField]
    private StringLogic StringLine;

    private XRGrabInteractable interactable;

    [SerializeField]
    // The Loader Object Area
    private Transform LoadGrabArea, LoadAreaVisual, LoadParent;

    // Constrain for the String Line
    [SerializeField]
    private float StringLineConstrain = 0.3f;

    // The Hand
    private Transform interactor;

    private float strenght;

    public UnityEvent OnBowPulled;
    public UnityEvent<float> OnBowReleased;

    private void Awake()
    {
        interactable = LoadGrabArea.GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        // When Hand (Interactor) enters it trigger the method load the string
        interactable.selectEntered.AddListener(LoadBowString);

        // When Hands (Interactor) exited it trigger the method to reset the string
        interactable.selectExited.AddListener(ResetBowString);
    }

    private void ResetBowString(SelectExitEventArgs arg0)
    {
        OnBowReleased?.Invoke(strenght);
        strenght = 0;

        interactable = null;

        // Set the string back to it original LocalPosition
        LoadGrabArea.localPosition = Vector3.zero;

        LoadAreaVisual.localPosition = Vector3.zero;

        // Recreate the line to be straight
        StringLine.CreateLine(null);
    }

    private void LoadBowString(SelectEnterEventArgs arg0)
    {
        // To get the Hand transform
        interactor = arg0.interactableObject.transform;

        OnBowPulled?.Invoke();
    }

    private void Update()
    {
        if (interactor != null)
        {
            // Convert load string grab area position to the local space of the mid position
            Vector3 LoadGrabAreaLocalSpace = LoadParent.InverseTransformPoint(LoadGrabArea.position);

            // Get the offset
            float LoadGrabAreaLocalZAbs = Mathf.Abs(LoadGrabAreaLocalSpace.z);

            HandleStringPushedBackToStart(LoadGrabAreaLocalSpace);

            HandleStringPulledBackToLimit(LoadGrabAreaLocalZAbs, LoadGrabAreaLocalSpace);

            HandlePullingString(LoadGrabAreaLocalZAbs, LoadGrabAreaLocalSpace);

            // Create a line when Hand (interactor) grab the load grab area
            StringLine.CreateLine(LoadAreaVisual.position);
        }
    }

    private void HandlePullingString(float loadGrabAreaLocalZAbs, Vector3 loadGrabAreaLocalSpace)
    {
        // Checks the value between point 0 and the string limit
        if (loadGrabAreaLocalSpace.z < 0 && loadGrabAreaLocalZAbs < StringLineConstrain)
        {
            strenght = Remap(loadGrabAreaLocalZAbs, 0, StringLineConstrain, 0, 1);

            // Force the line to stay on the z axis when the line is  move either x or y
            LoadAreaVisual.localPosition = new Vector3(0,0, loadGrabAreaLocalSpace.z);
        }
    }

    private float Remap(float value, int fromMin, float fromMax, int toMin, int toMax)
    {
        return (value - fromMin) / (fromMax - fromMin) * (toMax - toMin) + toMin;
    }

    private void HandleStringPulledBackToLimit(float loadGrabAreaLocalZAbs, Vector3 loadGrabAreaLocalSpace)
    {
        // Set max pulling limit for the string.
        if (loadGrabAreaLocalSpace.z < 0 && loadGrabAreaLocalZAbs >= StringLineConstrain)
        {
            strenght = 1;

            // Force the line to the position
            LoadAreaVisual.localPosition = new Vector3(0,0, -StringLineConstrain);
        }
    }

    private void HandleStringPushedBackToStart(Vector3 loadGrabAreaLocalSpace)
    {
        if (loadGrabAreaLocalSpace.z >= 0)
        {
            strenght = 0;

            // Set back the line to original position
            LoadAreaVisual.localPosition = Vector3.zero;
        }
    }
}
