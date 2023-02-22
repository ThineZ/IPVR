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
    public GameObject CowSkin;
    public GameObject MeatPrefab;

    private void Start()
    {
        MeatPrefab.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Spear")
        {
            collision.gameObject.GetComponent<SpearLogic>().Physics = this;
            isStick = true;

            SpearRB = GameObject.Find("HuntingSpearWithPhysics(Clone)").GetComponent<Rigidbody>();
            SpearCollider = GameObject.Find("HuntingSpearWithPhysics(Clone)").GetComponent<CapsuleCollider>();

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

            SpearRB = GameObject.Find("HuntingSpearWithPhysics(Clone)").GetComponent<Rigidbody>();
            SpearCollider = GameObject.Find("HuntingSpearWithPhysics(Clone)").GetComponent<CapsuleCollider>();

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
        StartCoroutine(DeathAnim());

        //Vector3 Pos = gameObject.transform.position;
        //Instantiate(MeatPrefab, Pos, Quaternion.identity);
        //MeatPrefab.name = "MeatFood";
        MeatPrefab.SetActive(true);
        MeatPrefab.GetComponent<Rigidbody>().isKinematic = false;

        var collider = GetComponent<Collider>();
        collider.enabled = false;

        StartCoroutine(EnableFall());
    }

    public IEnumerator DeathAnim()
    {
        CowAnim.runtimeAnimatorController = Controller;
        AnimalMovements.enabled = false;
        Agent.isStopped = true;
        yield return new WaitForSeconds(1f);
        CowSkin.SetActive(false);
    }
}
