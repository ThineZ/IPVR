using UltimateXR.Extensions.Unity;
using UnityEngine;

public class CursorOnCanvas : MonoBehaviour
{
    [SerializeField] private RectTransform Cursor;

    [SerializeField] private Transform Mouse;

    private void CursorMove()
    {
        // Set the Transform Position of Cursor X to the same as Mouse Position X
        Cursor.SetLocalPositionX(Mouse.transform.position.x - (0.372f));

        // Set the Transform Position of Cursor Y to the same as Mouse Position Z
        // As Cursor is 2D and Mouse is 3D
        Cursor.SetLocalPositionY(Mouse.transform.position.z);
    }

    private void CursorBoundX()
    {
        if (Cursor.transform.position.x <= -0.4)
        {
            Debug.Log("Cursor Position X is less then -0.4");
            Cursor.SetLocalPositionX(-0.4f);
        }

        if (Cursor.transform.position.x >= 0.4)
        {
            Debug.Log("Cursor Position X is more then 0.4");
            Cursor.SetLocalPositionX(0.4f);
        }
    }

    private void CursorBoundY()
    {
        if (Mouse.transform.position.z <= -0.4)
        {
            Debug.Log("Cursor Position Y is less then -0.4");
            Cursor.SetLocalPositionY(-0.4f);
        }

        if (Mouse.transform.position.z >= 0.4)
        {
            Debug.Log("Cursor Position Y is more then 0.4");
            Cursor.SetLocalPositionY(0.4f);
        }
    }

    private void Update()
    {
        CursorMove();
        CursorBoundX();
        CursorBoundY();
    }
}
