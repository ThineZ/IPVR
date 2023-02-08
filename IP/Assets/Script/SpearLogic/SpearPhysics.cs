using System.Collections;
using UnityEngine;

public class SpearPhysics : MonoBehaviour
{
    public Rigidbody SpearRB;

    public CapsuleCollider SpearCollider;

    public bool isStick = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spear")
        {
            isStick = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Spear")
        {
            isStick = false;
        }
    }

    public IEnumerator CheckForBool()
    {
        // To check if bool is false, then do this
        if (isStick)
        {
            yield return new WaitForSeconds(1f);
            isStick = false;
        }
    }

    private void FixedUpdate()
    {
        if (isStick)
        {
            SpearRB.isKinematic = true;
            SpearRB.useGravity = false;

            SpearCollider.isTrigger = true;

            Debug.Log("Spear Stick");
        }
        else
        {
            SpearRB.isKinematic = false;
            SpearRB.useGravity = true;

            SpearCollider.isTrigger = false;

            Debug.Log("Spear Not Stick");
        }
    }
}
