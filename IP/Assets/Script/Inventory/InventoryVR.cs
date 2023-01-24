// Script name: InventoryVR
// Script purpose: attaching a gameobject to a certain anchor and having the ability to enable and disable it.
// This script is a property of Realary, Inc

using UnityEngine;

public class InventoryVR : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject Anchor;
    bool UIActive;

    public InSlot slotOne;
    public InSlot slotTwo;
    public InSlot slotThree;
    public InSlot slotFour;

    private void Start()
    {
        Inventory.SetActive(false);
        UIActive = false;
    }

    private void Update()
    {
        //if (OVRInput.GetDown(OVRInput.Button.Four))
        //{
        //    UIActive = !UIActive;
        //    Inventory.SetActive(UIActive);
        //}
        if (Input.GetKeyDown(KeyCode.H))
        {
            UIActive = !UIActive;
            Inventory.SetActive(UIActive);

            if (slotOne.isEntered == true || slotTwo.isEntered == true || slotThree.isEntered == true || slotFour.isEntered == true)
            {
                slotOne.Obj[0].SetActive(false);
                slotTwo.Obj[0].SetActive(false);
                slotThree.Obj[0].SetActive(false);
                slotFour.Obj[0].SetActive(false);                
                slotOne.Obj[1].SetActive(false);
                slotTwo.Obj[1].SetActive(false);
                slotThree.Obj[1].SetActive(false);
                slotFour.Obj[1].SetActive(false);
            }
            else if(slotOne.isEntered == false || slotTwo.isEntered == false || slotThree.isEntered == false || slotFour.isEntered == false)
            {
                slotOne.Obj[0].SetActive(true);
                slotTwo.Obj[0].SetActive(true);
                slotThree.Obj[0].SetActive(true);
                slotFour.Obj[0].SetActive(true);                
                slotOne.Obj[1].SetActive(true);
                slotTwo.Obj[1].SetActive(true);
                slotThree.Obj[1].SetActive(true);
                slotFour.Obj[1].SetActive(true);
            }
        }
        if (UIActive)
        {
            Inventory.transform.position = Anchor.transform.position;
            Inventory.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);


            slotOne.Obj[0].SetActive(true);
            slotTwo.Obj[0].SetActive(true);
            slotThree.Obj[0].SetActive(true);
            slotFour.Obj[0].SetActive(true);
            slotOne.Obj[1].SetActive(true);
            slotTwo.Obj[1].SetActive(true);
            slotThree.Obj[1].SetActive(true);
            slotFour.Obj[1].SetActive(true);
        }
    }
}
