using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CursorRaycast : MonoBehaviour
{
    public Collider Cursor2D;

    public TMP_InputField InputFieldOne;

    private bool triggerEnter = false;

    public void InputOneSelect()
    {
        if (Input.GetMouseButtonDown(0) && triggerEnter == true)
        {
            InputFieldOne.Select();
            //InputFieldOne.OnSelect(new BaseEventData(EventSystem.current));
        }
        else if (Input.GetMouseButtonDown(0) && triggerEnter == false)
        {
            InputFieldOne.OnDeselect(new BaseEventData(EventSystem.current));
        }
    }   
    
    private void Update()
    {
        InputOneSelect();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OneInput")
        {
            Debug.Log("Cursor2D in InputOne");

            triggerEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "OneInput")
        {
            Debug.Log("Cursor2D exit InputOne");

            triggerEnter = false;
        }
    }
}