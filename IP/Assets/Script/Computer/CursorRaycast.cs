using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;


public class CursorRaycast : MonoBehaviour
{
    public Collider Cursor2D;

    public Image sRenderer;
    public Sprite ClickCursor;
    public Sprite DefaultCursor;

    public TMP_InputField InputFieldOne;
    public Toggle checkPwd;

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
                    InputFieldOne.Select();
                }
                else if(triggerEnter == false)
                {   
                    InputFieldOne.OnDeselect(new BaseEventData(EventSystem.current));
                }
            }

            if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isToggle) && isToggle)
            {
                checkPwd.isOn = true;
            }
            else
            {
                checkPwd.isOn = false;
            }
        }
    }

    //public void InputOneSelect()
    //{
    //    if (Input.GetKeyDown(KeyCode.A) && triggerEnter == true)
    //    {
    //        InputFieldOne.Select();
    //        //InputFieldOne.OnSelect(new BaseEventData(EventSystem.current));
    //    }
    //    else if (Input.GetKeyDown(KeyCode.A) && triggerEnter == false)
    //    {
    //        InputFieldOne.OnDeselect(new BaseEventData(EventSystem.current));
    //    }
    //}

    private void Update()
    {
        //InputOneSelect();

        GetDevices();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OneInput")
        {
            Debug.Log("Cursor2D in InputOne");

            sRenderer.sprite = ClickCursor;

            triggerEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "OneInput")
        {
            Debug.Log("Cursor2D exit InputOne");

            sRenderer.sprite = DefaultCursor;

            triggerEnter = false;
        }
    }
}