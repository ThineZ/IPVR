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

    private void OnTriggerStay(Collider other)
    {
        foreach (GameObject obj in Objects)
        {
            if (other.gameObject.name == obj.name)
            {
                Debug.Log("Object Tag " + obj.tag + " " + obj.name);

                obj.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                //Quaternion rotation = Quaternion.Euler(0.0f,-90.0f,0.0f);

                //obj.gameObject.transform.rotation = rotation;

                isEntered = true;
            }
        }
    }


    public void ItemExited(SelectExitEventArgs args)
    {
        foreach (GameObject obj in Objects)
        {
            if (interactor.interactablesSelected.Count == 0)
            {
                if (obj.name == Objects[0].name)
                {
                    Debug.Log("Object Tag " + obj.tag + " " + obj.name);

                    Objects[0].gameObject.transform.localScale = OriginScale[0];

                }

                if (obj.name == Objects[1].name)
                {
                    Debug.Log("Object Tag " + obj.tag + " " + obj.name);

                    Objects[1].gameObject.transform.localScale = OriginScale[1];
                }

                //if (obj.name == Objects[2].name)
                //{
                //    Debug.Log("Object Tag " + obj.name + " " + obj.name);

                //    Objects[2].gameObject.transform.localScale = OriginScale[2];
                //}                
                
                //if (obj.name == Objects[3].name)
                //{
                //    Debug.Log("Object Tag " + obj.name + " " + obj.name);

                //    Objects[3].gameObject.transform.localScale = OriginScale[3];
                //}
            }
        }
    }
}
