using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonDebug : MonoBehaviour
{
    public void NewTraining()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {

    }

    public void Exit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
