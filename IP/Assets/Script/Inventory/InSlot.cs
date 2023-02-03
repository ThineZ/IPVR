using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InSlot : MonoBehaviour
{
    public bool isEntered = false;

    [Header("Object List")]
    [SerializeField] private GameObject[] Objects;

    [SerializeField] private Vector3[] OriginScale;

    public XRSocketInteractor interactor;

    //foreach (GameObject obj in Objects)
    //{
    //    if (other.gameObject.tag == obj.tag)
    //    {
    //        Debug.Log("Object Tag " + obj.tag + " " + obj.name);

    //        obj.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);            
    //    }
    //}


    //foreach (GameObject obj in Objects)
    //{
    //    foreach (var scale in OriginScale)
    //    {
    //        if (other.gameObject.tag == obj.tag)
    //        {
    //            Debug.Log("Object Tag " + obj.tag + " " + obj.name);

    //            obj.gameObject.transform.localScale = scale;
    //        }
    //    }
    //}
    //Debug.Log("Item Exited");

    public void ItemSelected(SelectEnterEventArgs args)
    {
        foreach (GameObject obj in Objects)
        {
            if(interactor.interactablesSelected.Count > 0)
            {
                Debug.Log("Object Tag " + obj.tag + " " + obj.name);

                obj.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            }
        }
    }

    public void ItemExited(SelectExitEventArgs args)
    {
        foreach (GameObject obj in Objects)
        {
            foreach (var scale in OriginScale)
            {
                if (interactor.interactablesSelected.Count == 0)
                {
                    Debug.Log("Object Tag " + obj.tag + " " + obj.name);

                    obj.gameObject.transform.localScale = scale;
                }
            }
        }
    }
}
