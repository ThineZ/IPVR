using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.XR.Interaction.Toolkit;

public class InSlot : MonoBehaviour
{
    public XRSocketInteractor sockets;
    public string[] InvenTag;
    private int TagCount;

    public GameObject[] Obj;

    public bool isEntered = false;

    private void Awake()
    {
        sockets = GetComponent<XRSocketInteractor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "IObjOne")
        {
            Debug.Log("Item Enter");

            isEntered = true;
        }        
        
        if (other.gameObject.tag == "IObjTwo")
        {
            Debug.Log("Item Enter");

            isEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "IObjOne")
        {
            Debug.Log("Item Exited");

            isEntered = false;
        }        
        
        if (other.gameObject.tag == "IObjTwo")
        {
            Debug.Log("Item Exited");

            isEntered = false;
        }
    }

    public void SlotSocket()
    {
        if (sockets.interactablesSelected.Count > 0 && sockets.interactablesSelected[0].transform.CompareTag(InvenTag[0]))
        {
            //Debug.Log("TagCount Enter" + TagCount);

            Obj[0].transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        }        
        
        if (sockets.interactablesSelected.Count > 0 && sockets.interactablesSelected[0].transform.CompareTag(InvenTag[1]))
        {
            //Debug.Log("TagCount Enter" + TagCount);

            Obj[1].transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        }
    }

    public void SlotExited()
    {
        if (sockets.interactablesSelected.Count == 0)
        {
            //Debug.Log("TagCount Exited" + TagCount);

            Obj[0].transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }        
        
        if (sockets.interactablesSelected.Count == 0)
        {
            //Debug.Log("TagCount Exited" + TagCount);

            Obj[1].transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        }
    }
}
