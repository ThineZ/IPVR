using UnityEngine;

public class SpearBuild : MonoBehaviour
{
    [Header("Prefab Spear")]
    public GameObject PrefabSpear;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Branches")
        {
            Vector3 CurrentPos = other.transform.position;
            Instantiate(PrefabSpear, CurrentPos, Quaternion.identity);
            PrefabSpear.GetComponent<Rigidbody>().isKinematic = true;
            PrefabSpear.GetComponent<Collider>().isTrigger = false;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
