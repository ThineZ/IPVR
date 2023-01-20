using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorRaycast : MonoBehaviour
{
    public Collider Cursor2D;

    public Image sRenderer;
    public Sprite ClickCursor;
    public Sprite DefaultCursor;

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

            sRenderer.sprite = ClickCursor;

            triggerEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "OneInput")
        {
            Debug.Log("Cursor2D exit InputOne");

            sRenderer.sprite = DefaultCursor;

            triggerEnter = false;
        }
    }
}