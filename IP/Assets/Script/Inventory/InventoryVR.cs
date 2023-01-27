// Script name: InventoryVR
// Script purpose: attaching a gameobject to a certain anchor and having the ability to enable and disable it.
// This script is a property of Realary, Inc

using UnityEngine;

public class InventoryVR : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Anchor;
    bool UIActive;

    [SerializeField] private InSlot[] Slot_CS;

    private void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            UIActive = !UIActive;
            Inventory.SetActive(UIActive);

            for (int slotLoop = 0; Slot_CS.Length > slotLoop; ++slotLoop)
            {
                Slot_CS[slotLoop].SlotDisable();
            }
        }

        if (UIActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
    }
}
