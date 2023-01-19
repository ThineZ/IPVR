using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CusorRaycastTwo : MonoBehaviour
{
    public Collider Cursor2D;

    public TMP_InputField InputFieldTwo;

    private bool triggerEnter = false;

    public void InputTwoSelect()
    {
        if (Input.GetMouseButtonDown(0) && triggerEnter == true)
        {
            InputFieldTwo.Select();
            //InputFieldTwo.OnSelect(new BaseEventData(EventSystem.current));
        }
        else if (Input.GetMouseButtonDown(0) && triggerEnter == false)
        {
            InputFieldTwo.OnDeselect(new BaseEventData(EventSystem.current));
        }
    }

    private void Update()
    {
        InputTwoSelect();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TwoInput")
        {
            Debug.Log("Cursor2D in InputTwo");

            triggerEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TwoInput")
        {
            Debug.Log("Cursor2D exit InputTwo");

            triggerEnter = false;
        }
    }
}