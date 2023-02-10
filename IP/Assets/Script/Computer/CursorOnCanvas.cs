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
        if (Mouse.transform.position.y < 0.5f)
        {
            // To Get the previosPos
            Vector3 diffPos = Mouse.transform.position - PreviousPos;

            // Updating Cursor Pos X and Z
            CursorPos += new Vector3(diffPos.x, 0, diffPos.z);

            // Set the Transform Position of Cursor X to the same as Mouse Position X
            //Cursor.SetLocalPositionX(Mouse.transform.position.x - (0.372f));
            Cursor.SetLocalPositionX(CursorPos.x - (0.372f));

            // Set the Transform Position of Cursor Y to the same as Mouse Position Z
            // As Cursor is 2D and Mouse is 3D
            //Cursor.SetLocalPositionY(Mouse.transform.position.z);
            Cursor.SetLocalPositionY(CursorPos.z);
        }
        PreviousPos = Mouse.transform.position;
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
