using UltimateXR.Extensions.Unity;
using UnityEngine;

public class CursorOnCanvas : MonoBehaviour
{
    [SerializeField] private RectTransform Cursor;

    [SerializeField] private Transform Mouse;

    private Vector3 CursorPos;
    private Vector3 PreviousPos; 
 

    private void Start()
    {
        CursorPos = Mouse.transform.position;
        PreviousPos = CursorPos;
    }

    private void CursorMove()
    {
        if (Mouse.transform.position.y < 32f)
        {
            // To Get the previosPos
            Vector3 diffPos = Mouse.transform.position - PreviousPos;

            // Updating Cursor Pos X and Z
            CursorPos += new Vector3(diffPos.x, 0, diffPos.z);

            // Set the Transform Position of Cursor X to the same as Mouse Position X
            //Cursor.SetLocalPositionX(Mouse.transform.position.x - (0.372f));
            Cursor.SetLocalPositionX(Mathf.Abs(CursorPos.x + 18.592f));


            // Set the Transform Position of Cursor Y to the same as Mouse Position Z
            // As Cursor is 2D and Mouse is 3D
            //Cursor.SetLocalPositionY(Mouse.transform.position.z);
            Cursor.SetLocalPositionY(Mathf.Abs(CursorPos.z + 45.722f));
        }
        PreviousPos = Mouse.transform.position;
    }

    private void CursorBoundX()
    {
        if (Cursor.transform.position.x == -0.9)
        {
            Debug.Log("Cursor Position X is less then -0.9");
            Cursor.SetLocalPositionX(-0.9f);
        }

        if (Cursor.transform.position.x == 0.9)
        {
            Debug.Log("Cursor Position X is more then 0.9");
            Cursor.SetLocalPositionX(0.9f);
        }
    }

    private void CursorBoundY()
    {
        if (Mouse.transform.position.z == -0.45)
        {
            Debug.Log("Cursor Position Y is less then -0.4");
            Cursor.SetLocalPositionY(-0.45f);
        }

        if (Mouse.transform.position.z == 0.45)
        {
            Debug.Log("Cursor Position Y is more then 0.4");
            Cursor.SetLocalPositionY(0.45f);
        }
    }

    private void Update()
    {
        CursorMove();
        CursorBoundX();
        CursorBoundY();
    }
}
