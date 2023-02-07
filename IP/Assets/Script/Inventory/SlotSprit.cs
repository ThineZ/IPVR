using UnityEngine;
using UnityEngine.UI;

public class SlotSprit : MonoBehaviour
{
    [Header("Item Object")]
    [SerializeField] private GameObject[] Items;

    [Header("Item Picture")]
    [SerializeField] private Image[] ItemPicture;

    [Header("Item Sprite")]
    [SerializeField] private Sprite[] ItemSprite;

    [SerializeField] bool isSlotIn = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Axe")
        {
            ItemPicture[0].sprite = ItemSprite[0];

            Items[0].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

            isSlotIn = true;
        }

        if (other.gameObject.tag == "Bow")
        {
            ItemPicture[1].sprite = ItemSprite[1];

            Items[1].transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);

            isSlotIn = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Axe")
        {
            ItemPicture[0].sprite = ItemSprite[0];

            isSlotIn = true;
        }

        if (other.gameObject.tag == "Bow")
        {
            ItemPicture[1].sprite = ItemSprite[1];

            isSlotIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Axe")
        {
            ItemPicture[0].sprite = null;

            isSlotIn = false;
        }

        if (other.gameObject.tag == "Bow")
        {
            ItemPicture[1].sprite = null;

            isSlotIn = false;
        }
    }
}
