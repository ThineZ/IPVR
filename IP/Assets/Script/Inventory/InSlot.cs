using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.XR.Interaction.Toolkit;

public class InSlot : MonoBehaviour
{
    public XRSocketInteractor sockets;

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

            Obj[0].transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

            isEntered = true;
        }        
        
        if (other.gameObject.tag == "IObjTwo")
        {
            Debug.Log("Item Enter");

            Obj[1].transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

            isEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "IObjOne")
        {
            Debug.Log("Item Exited");

            Obj[0].transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

            isEntered = false;
        }        
        
        if (other.gameObject.tag == "IObjTwo")
        {
            Debug.Log("Item Exited");

            Obj[1].transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);

            isEntered = false;
        }
    }

    public void SlotDisable()
    {
        if (sockets.interactablesSelected.Count > 0 && isEntered == true)
        {
            sockets.interactablesSelected[0].transform.gameObject.SetActive(false);
            Debug.Log("Obj Disable!");
        }
    }
}
