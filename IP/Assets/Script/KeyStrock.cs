using System.Linq;
using TMPro;
using UnityEngine;

public class KeyStrock : MonoBehaviour
{
    public string Alpha;

    public TMP_InputField OneInput;
    public TMP_InputField TwoInput;

    private bool isKeyTrigger = false;

    private void KeyEnter()
    {
        if (OneInput.isFocused == true && isKeyTrigger == true)
        {
            OneInput.text = OneInput.text + Alpha.ToString();
        }

        else if (TwoInput.isFocused == true && isKeyTrigger == true)
        {
            TwoInput.text = TwoInput.text + Alpha.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "KeyBoardBase")
        {
            isKeyTrigger = true;
            Debug.Log("Key Trigger Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "KeyBoardBase")
        {
            isKeyTrigger = false;
            Debug.Log("Key Trigger Exit");
        }
    }

    private void Update()
    {
        if (isKeyTrigger == true)
        {
            KeyEnter();
        }
    }
}
