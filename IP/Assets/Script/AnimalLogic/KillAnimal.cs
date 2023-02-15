using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class KillAnimal : MonoBehaviour
{
    public Rigidbody SpearRB;

    public CapsuleCollider SpearCollider;

    public Animator CowAnim;
    public RuntimeAnimatorController Controller;
    public AnimalMovements AnimalMovements;
    public NavMeshAgent Agent;

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

            CowAnim.runtimeAnimatorController = Controller;
            AnimalMovements.enabled = false;
            Agent.enabled = false;

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
