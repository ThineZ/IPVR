using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject LoadAreaVisual, arrowPrefab, arrowSpawnPoint;

    [SerializeField]
    private float arrowMaxSpeed = 10;

    public void PrepareArrow()
    {
        LoadAreaVisual.SetActive(true);
    }

    public void ReleaseArrow(float strenght)
    {
        LoadAreaVisual.SetActive(false);

        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = arrowSpawnPoint.transform.position;
        arrow.transform.rotation = LoadAreaVisual.transform.rotation;
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.AddForce(LoadAreaVisual.transform.forward * strenght * arrowMaxSpeed, ForceMode.Impulse);
    }
}
