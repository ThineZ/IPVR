using UltimateXR.Manipulation;
using UnityEngine;

public class HintBuildShelter : MonoBehaviour
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
                Object.transform.rotation= transform.rotation;

                Object.GetComponent<UxrGrabbableObject>().enabled = false;

                Object.GetComponent<Rigidbody>().isKinematic = true;
                Object.GetComponent<Rigidbody>().useGravity = false;

                gameObject.SetActive(false);
            }
        }
    }

    public void CheckForGrab()
    {
        if (Object.GetComponent<UxrGrabbableObject>().IsBeingGrabbed)
        {
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void Update()
    {
        CheckForGrab();
    }
}
