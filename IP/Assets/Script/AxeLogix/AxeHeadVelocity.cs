using TMPro;
using UnityEngine;

public class AxeHeadVelocity : MonoBehaviour
{
    [Header("Axe RD")]
    public Rigidbody AxeHeadRB;

    [Header("Wood Health UI")]
    public TMP_Text WoodHealth;

    [Header("Wood Object")]
    public GameObject WoodObj;

    [Header("Choped Half Wood")]
    public GameObject HalfOne;
    public GameObject HalfTwo;

    int totalHealth = 5;

    private void Awake()
    {
        HalfOne = GameObject.Find("HalfOne");
        HalfTwo = GameObject.Find("HalfTwo");
        WoodObj = GameObject.Find("Wood");
        WoodHealth = GameObject.Find("Health").GetComponent<TMP_Text>();
        WoodHealth.text = totalHealth.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wood")
        {
            Vector3 ImpactForce = collision.impulse / Time.deltaTime;

            var ForceX = ImpactForce.x;

            Debug.Log("Impact Force " + ImpactForce);
            Debug.Log("Impact Force X " + ForceX);

            if (ForceX > 60f)
            {
                totalHealth--;
                WoodHealth.text = totalHealth.ToString();

                if (totalHealth <= 4)
                {
                    WoodHealth.color = Color.yellow;
                }

                if (totalHealth <= 2)
                {
                    WoodHealth.color = Color.red;
                }

                if (totalHealth == 0)
                {
                    totalHealth = 0;
                    WoodObj.SetActive(false);

                    HalfOne.transform.localPosition = WoodObj.transform.localScale;
                    HalfOne.transform.localRotation = WoodObj.transform.rotation;                   
                    
                    HalfTwo.transform.localPosition = WoodObj.transform.localScale;
                    HalfTwo.transform.localRotation = WoodObj.transform.rotation;

                    HalfOne.SetActive(true);
                    HalfTwo.SetActive(true);
                }
            }
        }
    }
}
