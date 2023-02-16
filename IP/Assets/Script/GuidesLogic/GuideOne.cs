using UltimateXR.Manipulation;
using UnityEngine;

public class GuideOne : MonoBehaviour
{
    [Header("Guides Object")]
    public GameObject[] Guides;

    [Header("Grabble Objects")]
    public GameObject Plug;
    public GameObject Mouse;


    public void CheckGuides()
    {
        var PlugGrab = Plug.GetComponent<UxrGrabbableObject>().IsBeingGrabbed;
        var MouseGrab = Mouse.GetComponent<UxrGrabbableObject>().IsBeingGrabbed;

        if (PlugGrab)
        {
            Guides[1].SetActive(true);
            Guides[0].SetActive(false);
        }

        if (MouseGrab)
        {
            Guides[3].SetActive(true);
            Guides[4].SetActive(true);
            Guides[5].SetActive(true);
            Guides[1].SetActive(false);
            Guides[2].SetActive(false);
        }
    }

    private void Update()
    {
        CheckGuides();
    }
}
