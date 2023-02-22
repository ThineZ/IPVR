using UltimateXR.Manipulation;
using UnityEngine;

public class MeatHint : MonoBehaviour
{
    [Header("Object")]
    public GameObject Object;

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Object)
        {

            if (!Object.GetComponent<UxrGrabbableObject>().IsBeingGrabbed)
            {
                Object.transform.position = transform.position;
                Object.transform.rotation = transform.rotation;

                Object.GetComponent<UxrGrabbableObject>().enabled = true;

                Object.GetComponent<Rigidbody>().isKinematic = true;
                Object.GetComponent<Rigidbody>().useGravity = false;

                GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Beef" || other.gameObject.tag == "Cook")
        {
            Object = GameObject.Find("Meat");
            CheckIfColliderTrigger();
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Beef" || other.gameObject.tag == "Cook")
        {
            Object = GameObject.Find("Meat");
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void CheckIfColliderTrigger()
    {
        if (Object.GetComponent<UxrGrabbableObject>().IsBeingGrabbed)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
