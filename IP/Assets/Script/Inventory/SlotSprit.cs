using UltimateXR.Manipulation;
using UnityEngine;
using UnityEngine.UI;

public class SlotSprit : MonoBehaviour
{
    [Header("Item Object")]
    [SerializeField] private GameObject[] Items;

    [Header("Item Picture")]
    [SerializeField] private Image ItemPicture;

    [Header("Item Sprite")]
    [SerializeField] private Sprite[] ItemSprite;

    [Header("Slot List")]
    [SerializeField] private GameObject Slots;

    [SerializeField] bool isSlotIn = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Axe")
        {
            var grabObject = other.gameObject.GetComponent<UxrGrabbableObject>().IsBeingGrabbed;

            if(!grabObject)
                Items[0].transform.SetParent(Slots.transform, true);

            ItemPicture.sprite = ItemSprite[0];

            Items[0] = GameObject.Find("AxeV2(Clone)");


            Items[0].GetComponent<Rigidbody>().isKinematic = true;

            Debug.Log(Slots.transform.name);

            isSlotIn = true;
        }

        if (other.gameObject.tag == "Bow")
        {
            var grabObject = other.gameObject.GetComponent<UxrGrabbableObject>().IsBeingGrabbed;

            Debug.Log(grabObject);

            if (!grabObject)
                Items[1].transform.SetParent(Slots.transform, true);

            ItemPicture.sprite = ItemSprite[1];

            Items[1] = GameObject.Find("BowBB(Clone)");

            //Items[1].transform.SetParent(Slots.transform, true);

            Items[1].GetComponent<Rigidbody>().isKinematic = true;
            
            Debug.Log(Slots.transform.name);

            isSlotIn = true;
        }            
        
        if (other.gameObject.tag == "Spear")
        {
            var grabObject = other.gameObject.GetComponent<UxrGrabbableObject>().IsBeingGrabbed;

            Debug.Log(grabObject);

            if (!grabObject)
                Items[2].transform.SetParent(Slots.transform, true);

            ItemPicture.sprite = ItemSprite[2];

            Items[2] = GameObject.Find("HuntingSpearWithPhysics(Clone)");

            //Items[1].transform.SetParent(Slots.transform, true);

            Items[2].GetComponent<Rigidbody>().isKinematic = true;
            
            Debug.Log(Slots.transform.name);

            isSlotIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Axe")
        {
            ItemPicture.sprite = null;

            isSlotIn = false;

            Items[0].transform.SetParent(null);

            Items[0].GetComponent<Rigidbody>().isKinematic = false;
        }

        if (other.gameObject.tag == "Bow")
        {
            ItemPicture.sprite = null;

            isSlotIn = false;

            Items[1].transform.SetParent(null);

            Items[1].GetComponent<Rigidbody>().isKinematic = false;
        }        

        if (other.gameObject.tag == "Spear")
        {
            ItemPicture.sprite = null;

            isSlotIn = false;

            Items[2].transform.SetParent(null);

            Items[2].GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
