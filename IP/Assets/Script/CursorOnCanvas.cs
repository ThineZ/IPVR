using UltimateXR.Extensions.Unity;
using UnityEngine;
using TMPro;

public class CursorOnCanvas : MonoBehaviour
{
    [SerializeField] private RectTransform Cursor;
    [SerializeField] private RectTransform CanvasSize;

    [SerializeField] private Transform Mouse;

    [SerializeField] private float CursorWidth;
    [SerializeField] private float CursorHeight;

    public TMP_InputField InputFieldOne; // 0
    public TMP_InputField InputFieldTwo; // 1

    public void GetMouseClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            InputFieldOne.Select();
        }        
    }

    private void CursorMove()
    {
        // Set the Transform Position of Cursor X to the same as Mouse Position X
        Cursor.SetLocalPositionX(Mouse.transform.position.x);

        // Set the Transform Position of Cursor Y to the same as Mouse Position Z
        // As Cursor is 2D and Mouse is 3D
        Cursor.SetLocalPositionY(Mouse.transform.position.z);
    }

    private void Start()
    {
        CursorWidth = Cursor.rect.width;
        CursorHeight = Cursor.rect.height;

        GetMouseClick();
    }

    private void Update()
    {
        CursorMove();
    }
}
