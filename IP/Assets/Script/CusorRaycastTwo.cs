using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CusorRaycastTwo : MonoBehaviour
{
    public Collider Cursor2D;

    public Image sRenderer;
    public Sprite ClickCursor;
    public Sprite DefaultCursor;

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

            sRenderer.sprite = ClickCursor;

            triggerEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        if (other.gameObject.tag == "TwoInput")
        {
            Debug.Log("Cursor2D exit InputTwo");

            sRenderer.sprite = DefaultCursor;
            
            triggerEnter = false;
        }
    }
}