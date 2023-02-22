using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CookLogic : MonoBehaviour
{
    [Header("Cooking UI")]
    public Slider CookMeter;
    public Image Fill;

    [Header("Cooked Object")]
    public GameObject RawPrefab;
    public Material CookMat;

    bool isCooking;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Beef")
        {
            isCooking = true;
            RawPrefab = GameObject.Find("Meat");
            StartCoroutine(Cooking());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Beef")
        {
            isCooking = false;
        }

        if (other.gameObject.tag == "Cook")
        {
            isCooking = false;
        }
    }

    private void Update()
    {
        if(!isCooking)
        {
            CookMeter.value -= (float)0.5 * Time.deltaTime;
        }
    }

    IEnumerator Cooking()
    {
        yield return new WaitForSeconds(5f);

        CookMeter.value += (float)0.05 * Time.deltaTime;

        if (CookMeter.value >= 0.3f)
        {
            Fill.color = Color.yellow;

            if (CookMeter.value >= 0.7f)
            {
                Fill.color = Color.green;

                if (CookMeter.value == 1f)
                {
                    RawPrefab.GetComponent<MeshRenderer>().material = CookMat;
                    RawPrefab.gameObject.tag = "Cook";
                }
            }
        }
    }
}
