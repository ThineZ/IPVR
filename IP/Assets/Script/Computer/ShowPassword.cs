using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPassword : MonoBehaviour
{
    [SerializeField] private Toggle checkPwd;
    [SerializeField] private TMP_InputField InputFieldTwo;

    private void isToggle()
    {
        if (checkPwd.isOn)
        {
            InputFieldTwo.contentType = TMP_InputField.ContentType.Standard;
        }
        else
        {
            InputFieldTwo.contentType = TMP_InputField.ContentType.Password;
        }
    }

    private void Awake()
    {
        isToggle();
    }
}
