using System.Collections.Generic;
using UltimateXR.Extensions.Unity;
using Unity.VisualScripting;
using Unity.XR.Oculus;
using UnityEngine;
using UnityEngine.XR;

public class SpawnInventory : MonoBehaviour
{
    [Header("Inventory Canvas")]
    [SerializeField] private GameObject inventory;
    public GameObject Anchorsss;
    bool UIActive;

    private void Awake()
    {
        //inventory.SetActive(false);
        UIActive = true;
    }

    private void GetDevices()
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

            if (device.TryGetFeatureValue(OculusUsages.thumbrest, out bool isPressed) && isPressed)
            {
                if (UIActive)
                {
                    inventory.transform.position = Anchorsss.transform.position;
                    inventory.transform.eulerAngles = new Vector3(Anchorsss.transform.eulerAngles.x + 15, Anchorsss.transform.eulerAngles.y, 0);
                    Debug.Log("Inventory Shown");
                }
            }

            if (device.TryGetFeatureValue(OculusUsages.thumbrest, out bool isPPressed) && isPPressed == false)
            {
                if (isPressed == false)
                {
                    var posInv = inventory.transform.position;

                    inventory.transform.position = new Vector3(
                        posInv.x, -90, posInv.z);

                    Debug.Log("Inventory Hidden");
                }
            }
        }
    }

    private void Update()
    {
        GetDevices();
    }
}
