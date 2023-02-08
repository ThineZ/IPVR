using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpAmount = 2.0f;
    public Vector3 jump;
    public bool isGrounded;

    public CapsuleCollider capsuleCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void GetLeftHeldDevice()
    {
        var inputDevices = new List<InputDevice>();
        var LeftHeldInHand = InputDeviceCharacteristics.HeldInHand |
            InputDeviceCharacteristics.TrackedDevice |
            InputDeviceCharacteristics.Controller |
            InputDeviceCharacteristics.Left;

        InputDevices.GetDevicesWithCharacteristics(LeftHeldInHand, inputDevices);

        foreach (var device in inputDevices)
        {
            Debug.Log(device.name + device.characteristics);

            if (device.TryGetFeatureValue(CommonUsages.primaryButton, out bool isYPressed) && isYPressed && isGrounded)
            {
                Debug.Log("Left Primary Button is Pressed");

                rb.AddForce(jump * jumpAmount, ForceMode.Impulse);
                isGrounded = false;
            }

            if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isXPressed) && isXPressed)
            {
                Debug.Log("Left Secondary Button is Pressed");

                capsuleCollider.height = -0.1f;
            }

            if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isXXPressed) && isXXPressed == false)
            {
                capsuleCollider.height = 0.5f;
            }
        }
    }

    private void Update()
    {
        GetLeftHeldDevice();
    }
}
