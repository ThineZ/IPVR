using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.XR;

public class CusorRaycastTwo : MonoBehaviour
{
    public Collider Cursor2D;

    public Image sRenderer;
    public Sprite ClickCursor;
    public Sprite DefaultCursor;

    public TMP_InputField InputFieldTwo;

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
                    InputFieldTwo.Select();
                }
                else if (triggerEnter == false)
                {
                    InputFieldTwo.OnDeselect(new BaseEventData(EventSystem.current));
                }
            }
        }
    }

    //public void InputTwoSelect()
    //{
    //    if (Input.GetKeyDown(KeyCode.A) && triggerEnter == true)
    //    {
    //        InputFieldTwo.Select();
    //        //InputFieldOne.OnSelect(new BaseEventData(EventSystem.current));
    //    }
    //    else if (Input.GetKeyDown(KeyCode.A) && triggerEnter == false)
    //    {
    //        InputFieldTwo.OnDeselect(new BaseEventData(EventSystem.current));
    //    }
    //}

    private void Update()
    {
        //InputTwoSelect();
        GetDevices();
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject.tag == "TwoInput")
        {
            Debug.Log("Cursor2D in InputTwo");

            sRenderer.sprite = ClickCursor;

            triggerEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        if (other.gameObject.tag == "TwoInput")
        {
            Debug.Log("Cursor2D exit InputTwo");

            sRenderer.sprite = DefaultCursor;
            
            triggerEnter = false;
        }
    }
}