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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Axe")
        {
            ItemPicture.sprite = ItemSprite[0];

            Items[0].transform.SetParent(Slots.transform, true);

            Items[0].GetComponent<Rigidbody>().isKinematic = true;

            Debug.Log(Slots.transform.name);

            isSlotIn = true;
        }

        if (other.gameObject.tag == "Bow")
        {
            ItemPicture.sprite = ItemSprite[1];

            Items[1].transform.SetParent(Slots.transform, true);

            Items[1].GetComponent<Rigidbody>().isKinematic = true;
            
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
    }
}
