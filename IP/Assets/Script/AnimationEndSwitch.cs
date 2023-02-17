using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEndSwitch : MonoBehaviour
{
    public void CheckAnimEnded()
    {
        SceneManager.LoadScene(3);
    }
}
