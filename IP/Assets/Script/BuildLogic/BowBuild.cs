using UnityEngine;

public class BowBuild : MonoBehaviour
{
    [Header("Prefab Bow")]
    public GameObject PrefabBow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "String")
        {
            Vector3 CurrentPos = other.transform.position;
            Instantiate(PrefabBow, CurrentPos, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
