using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

public class CursorRaycastThree : MonoBehaviour
{
    public Collider Cursor2D;

    public Image sRenderer;
    public Sprite ClickCursor;
    public Sprite DefaultCursor;

    public Button SignUpBTN;

    public bool triggerEnter = false;

    private void GetDevices()
    {
        var inputDevices = new List<InputDevice>();
        var RightHeldInHand = InputDeviceCharacteristics.HeldInHand |
            InputDeviceCharacteristics.TrackedDevice |
            InputDeviceCharacteristics.Controller |
            InputDeviceCharacteristics.Right;

        InputDevices.GetDevicesWithCharacteristics(RightHeldInHand, inputDevices);

        foreach (var device in inputDevices)
        {
            Debug.Log(device.name + device.characteristics);

            if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isPressed) && isPressed)
            {
                Debug.Log("Primary Button Is Pressed");

                if (triggerEnter == true)
                {
                    SignUpBTN.onClick.Invoke();
                }
            }
        }
    }

    private void Update()
    {
        GetDevices();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SignUpBTN")
        {
            Debug.Log("Cursor2D in SignUpBTN");

            sRenderer.sprite = ClickCursor;

            triggerEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SignUpBTN")
        {
            Debug.Log("Cursor2D exit SignUpBTN");

            sRenderer.sprite = DefaultCursor;

            triggerEnter = false;
        }
    }
}
