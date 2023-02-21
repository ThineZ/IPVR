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
            Object = GameObject.Find("MeatFood");

            if (!Object.GetComponent<UxrGrabbableObject>().IsBeingGrabbed)
            {
                Object.transform.position = transform.position;
                Object.transform.rotation = transform.rotation;

                Object.GetComponent<Rigidbody>().isKinematic = true;
                Object.GetComponent<Rigidbody>().useGravity = false;

                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Object)
        {
            CheckIfColliderTrigger();
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
