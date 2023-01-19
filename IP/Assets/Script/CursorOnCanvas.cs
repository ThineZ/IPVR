using UltimateXR.Extensions.Unity;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class CursorOnCanvas : MonoBehaviour
{
    [SerializeField] private RectTransform Cursor;
    [SerializeField] private RectTransform CanvasSize;

    [SerializeField] private Transform Mouse;

    [SerializeField] private float CursorWidth;
    [SerializeField] private float CursorHeight;


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
    }

    private void Update()
    {
        CursorMove();
    }
}
