using Firebase.Auth;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public GameObject Food;
    public int EatCountAdder;

    // Firebase Object
    [Header("Firebase")]
    public PlayerStatesDB PSDB;
    public FirebaseAuth Auth;
    public FirebaseUser User;

    public SunLogic SunLogic;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        Auth = FirebaseAuth.DefaultInstance;
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

            // To Jump
            if (device.TryGetFeatureValue(CommonUsages.primaryButton, out bool isYPressed) && isYPressed && isGrounded)
            {
                Debug.Log("Left Primary Button is Pressed");

                rb.AddForce(jump * jumpAmount, ForceMode.Impulse);
                isGrounded = false;
            }

            // To Crouch
            if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isXPressed) && isXPressed)
            {
                Debug.Log("Left Secondary Button is Pressed");

                capsuleCollider.height = -0.5f;
            }

            if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isXXPressed) && isXXPressed == false)
            {
                capsuleCollider.height = 0.5f;
            }

            // To Eat
            if (device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool isLeftTrigger) && isLeftTrigger)
            {
                UpdateEatStates();
            }
        }
    }

    public void UpdateEatStates()
    {
        if (Food.transform.gameObject.tag == "Cook")
        {
            if (EatCountAdder == 0)
            {
                EatCountAdder += 1;
                Food.SetActive(false);
                //Food.transform.gameObject.tag = "Beef";
                UpdatePlayerState(SunLogic.ReturnDayTime(), ReturnEatCount());
            }
        }
    }

    public int ReturnEatCount()
    {
        return EatCountAdder;
    }

    public void UpdatePlayerState(int TimeCount ,int EatCount)
    {
        PSDB.UpdatePlayerStats(Auth.CurrentUser.UserId, TimeCount, EatCount);
    }

    private void Update()
    {
        GetLeftHeldDevice();
    }
}
