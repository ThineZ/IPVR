using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Require LineRenderer Object
[RequireComponent(typeof(LineRenderer))]

public class StringLogic : MonoBehaviour
{
    [SerializeField]
    private Transform TopEnd, BottomEnd;

    private LineRenderer StringLine;

    private void Awake()
    {
        StringLine= GetComponent<LineRenderer>();
    }

    public void CreateLine(Vector3? midPostion)
    {
        // If is true set the Vector3 array to 2, if is false set the Vector3 array to 3
        Vector3[] linePoints = new Vector3[midPostion == null ? 2 : 3];

        linePoints[0] = TopEnd.localPosition;

        if (midPostion != null)
        { 
            linePoints[1] = transform.InverseTransformPoint(midPostion.Value);
        }
        // Get the last position of the BottomEnd Position
        linePoints[^1] = BottomEnd.localPosition;

        // Set the Line Renderer to the end points
        StringLine.positionCount = linePoints.Length;
        StringLine.SetPositions(linePoints);
    }

    private void Start()
    {
        CreateLine(null);
    }
}
