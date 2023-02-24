using System.Collections;
using UnityEngine;

public class GameSceceUI : MonoBehaviour
{
    public GameObject[] ItemList;

    public GameObject[] BigUIList;

    public GameObject[] AxeGuide;

    public GameObject[] SpearGuide;

    public GameObject Meat;

    public GameObject[] ShelterHint;

     public bool show = false;

    private void Start()
    {
        StartCoroutine(AxeTimer());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            show = true;

            BigUIList[0].SetActive(false);
            BigUIList[1].SetActive(true);
        }
    }

    private IEnumerator AxeTimer()
    {
        yield return new WaitForSeconds(7);

        AxeGuide[0].SetActive(true);

        yield return new WaitForSeconds(8);

        AxeGuide[0].SetActive(false);
        AxeGuide[1].SetActive(true);

        yield return new WaitForSeconds(9);

        AxeGuide[1].SetActive(false);
        AxeGuide[2].SetActive(true);

        yield return new WaitForSeconds(10);

        AxeGuide[2].SetActive(false);
        AxeGuide[3].SetActive(true);
    }

    private IEnumerator SpearTimer()
    {
        BigUIList[2].SetActive(true);

        yield return new WaitForSeconds(5);

        SpearGuide[0].SetActive(false);
        SpearGuide[1].SetActive(true);
    }

    private IEnumerator ShelterTime()
    {
        BigUIList[4].SetActive(true);

        yield return new WaitForSeconds(5);

        BigUIList[5].SetActive(true);

        yield return new WaitForSeconds(6);

        ItemList[3].SetActive(true);
        ItemList[4].SetActive(true);
    }

    private void Update()
    {
        if (show)
        {
            ItemList[0].SetActive(true);
            ItemList[1].SetActive(true);
        }

        if (GameObject.Find("AxeV2(Clone)") != null)
        {
            ItemList[0].SetActive(false);
            ItemList[1].SetActive(false); 
            ItemList[2].SetActive(true);
        }

        if (GameObject.Find("TargetBrunchersA(Clone)") != null)
        {
            StartCoroutine(SpearTimer());
        }

        if (GameObject.Find("Target Tree") == null)
        {
            ItemList[2].SetActive(false);
            BigUIList[1].SetActive(false);
        }

        if (GameObject.Find("HuntingSpearWithPhysics(Clone)") != null)
        {
            BigUIList[2].SetActive(false);
            BigUIList[3].SetActive(true);
        }

        if (Meat.activeInHierarchy == true)
        {
            BigUIList[3].SetActive(false);
            StartCoroutine(ShelterTime());
        }

        if (ShelterHint[0].activeInHierarchy == false || 
            ShelterHint[1].activeInHierarchy == false || 
            ShelterHint[2].activeInHierarchy == false || 
            ShelterHint[3].activeInHierarchy == false ||
            ShelterHint[4].activeInHierarchy == false ||
            ShelterHint[5].activeInHierarchy == false)
        {
            BigUIList[4].SetActive(false);
            BigUIList[5].SetActive(false);
            BigUIList[6].SetActive(true);
            ItemList[5].SetActive(true);
        }


        if (Meat.activeInHierarchy == false)
        {
            BigUIList[6].SetActive(false);
            ItemList[5].SetActive(false);
        }
    }
}
