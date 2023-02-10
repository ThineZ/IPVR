using UnityEngine;

public class FireRod : MonoBehaviour
{   
    [Header("Hands")]
    [SerializeField] private GameObject LeftHand;
    [SerializeField] private GameObject RightHands;

    public void RotateRod()
    {
        // Get Hands Movement of Z to increase the rotation Y of FireRod
        if(transform.position.y < 0.54 && LeftHand.transform.position.z > 0 && RightHands.transform.position.z < 0 || 
            LeftHand.transform.position.z < 0 && RightHands.transform.position.z > 0)
        {
            Quaternion RotationY = transform.rotation;

            RotationY.y++;

            Debug.Log("Is Rotating");
        }
    }

    private void Update()
    {
        RotateRod();
    }
}
