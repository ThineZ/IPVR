using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractible : XRBaseInteractable
{
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        Debug.Log("Select Enter!");
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExiting(args);
    }
}
