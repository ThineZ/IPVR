using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SpearLogic : MonoBehaviour
{
    [Header("Spear RB")]
    [SerializeField] private Rigidbody SpearRB;

    [Header("Streght")]
    public float speed = 1000.0f;

    public SpearPhysics Physics;

    private void Awake()
    {
        SpearRB = GetComponent<Rigidbody>();
        SpearRB.isKinematic = false;
        SpearRB.useGravity = true;
    }

    private void GetDevice()
    {
        var inputDevices = new List<InputDevice>();
        var HeldInHand = InputDeviceCharacteristics.HeldInHand |
            InputDeviceCharacteristics.TrackedDevice |
            InputDeviceCharacteristics.Controller |
            InputDeviceCharacteristics.Right;

        InputDevices.GetDevicesWithCharacteristics(HeldInHand, inputDevices);

        foreach (var device in inputDevices)
        {
            if (device.TryGetFeatureValue(CommonUsages.triggerButton, out bool isGriped) && isGriped)
            {
                Throw();
                StartCoroutine(Physics.CheckForBool());
            }
        }
    }

    public void Throw()
    {
        SpearRB.velocity = transform.up * 20;   
    }

    private void FixedUpdate()
    {
        GetDevice();
    }
}
