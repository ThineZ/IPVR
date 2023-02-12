using TMPro;
using UnityEngine;

public class TreeTrunkChopLogic : MonoBehaviour
{
    [Header("Choped Trunck Object")]
    public GameObject TrunkOne;
    public GameObject TrunkTwo;

    [Header("Trunk Health")]
    public TMP_Text TrunkHealth;

    [Header("Trunk Object")]
    public GameObject Trunk;

    int totalHealth = 5;

    private void Start()
    {
        // Get the Trunk Object
        Trunk = GameObject.Find("Wood");

        // Get the Trunk Health UI
        TrunkHealth = GameObject.Find("Health").GetComponent<TMP_Text>();
        TrunkHealth.text = totalHealth.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Axe")
        {
            totalHealth--;
            TrunkHealth.text = totalHealth.ToString();

            if (totalHealth <= 4)
            {
                TrunkHealth.color = Color.yellow;

            }
            if (totalHealth <= 2)
            {
                TrunkHealth.color = Color.red;

            }
            if (totalHealth == 0)
            {

                Vector3 CurrentTrunkPosOne = Trunk.transform.position;
                Vector3 CurrentTrunkPosTwo = Trunk.transform.position;

                Instantiate(TrunkOne, CurrentTrunkPosOne, Quaternion.identity);
                Instantiate(TrunkTwo, CurrentTrunkPosTwo, Quaternion.identity);

                Destroy(Trunk);
            }
        }
    }
}
