using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class SpearPhysics : MonoBehaviour
{
    public Rigidbody SpearRB;

    public CapsuleCollider SpearCollider;

    public bool isStick = false;

    public UnityEvent HitEvent;

    public Animator CowAnim;
    public RuntimeAnimatorController Controller;
    public AnimalMovements AnimalMovements;
    public NavMeshAgent Agent;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spear")
        {
            collision.gameObject.GetComponent<SpearLogic>().Physics = this;
            isStick = true; 
            
            SpearRB.isKinematic = true;
            SpearRB.useGravity = false;

            SpearCollider.isTrigger = true;

            HitEvent.Invoke();

            Debug.Log("Spear Stick");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Spear")
        {
            isStick = false;

            SpearRB.isKinematic = false;
            SpearRB.useGravity = true;

            SpearCollider.isTrigger = false;

            Debug.Log("Spear Not Stick");
        }
    }

    public IEnumerator CheckForBool()
    {
        // To check if bool is false, then do this
        if (isStick)
        {
            yield return new WaitForSeconds(1f);
            isStick = false;

            SpearRB.isKinematic = false;
            SpearRB.useGravity = true;

            SpearCollider.isTrigger = false;

            Debug.Log("Spear Not Stick");
        }
    }

    private void Update()
    {
        if (isStick)
        {
            //SpearRB.isKinematic = true;
            //SpearRB.useGravity = false;

            //SpearCollider.isTrigger = true;

            //HitEvent.Invoke();

            //Debug.Log("Spear Stick");
        }
        else
        {
            //SpearRB.isKinematic = false;
            //SpearRB.useGravity = true;

            //SpearCollider.isTrigger = false;

            //Debug.Log("Spear Not Stick");
        }
    }

    public IEnumerator EnableFall()
    {
        yield return new WaitForSeconds(0.05f);
        isStick = false;

        SpearRB.isKinematic = false;
        SpearRB.useGravity = true;

        SpearCollider.isTrigger = false;
    }

    public void HitAnimal()
    {
        CowAnim.runtimeAnimatorController = Controller;
        AnimalMovements.enabled = false;
        Agent.enabled = false;

        var collider = GetComponent<Collider>();
        collider.enabled = false;

        StartCoroutine(EnableFall());
    }
}
