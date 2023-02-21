using UnityEngine;

public class TerrainBlock : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Spear")
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spear")
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Spear")
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        }
    }
}
