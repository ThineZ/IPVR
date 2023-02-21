using UnityEngine;

public class CameraTimeLine : MonoBehaviour
{
    public Animation Anim;

    private void Start()
    {
        Anim = gameObject.GetComponent<Animation>();
        Anim.Play("Camera");
    }
}
