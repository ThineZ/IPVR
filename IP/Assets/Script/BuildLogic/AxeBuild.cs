using UnityEngine;

public class AxeBuild : MonoBehaviour
{
    [Header("Axe Prefab")]
    public GameObject Axe;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Rock")
        {
            Vector3 CurrentPos = other.transform.position;
            Instantiate(Axe, CurrentPos, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
