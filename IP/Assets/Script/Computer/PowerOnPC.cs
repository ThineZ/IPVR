using UnityEngine;
using UnityEngine.UI;

public class PowerOnPC : MonoBehaviour
{    
    [Header("Power Button")]
    public Button PowerButton;

    [Header("Screen Types")]
    [SerializeField] private Image OffScreen;
    [SerializeField] private Image OnScreen;

    [SerializeField] private bool isPlugIn = false;

    [Header("Guides")]
    public GameObject G4;
    public GameObject G3;
    public GameObject G2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Plug")
        {
            isPlugIn = true;
            PowerButton.image.color = Color.red;
            G2.SetActive(false);
            G3.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Plug")
        {
            isPlugIn = false;
            PowerButton.image.color = Color.black;
            OffScreen.transform.gameObject.SetActive(true);
            OnScreen.transform.gameObject.SetActive(false);
        }
    }

    public void PowerOn()
    {
        if (isPlugIn == true)
        {
            PowerButton.image.color = Color.green;
            OffScreen.transform.gameObject.SetActive(false);
            OnScreen.transform.gameObject.SetActive(true);

            G3.SetActive(false);
            G4.SetActive(true);
        }
        else if (isPlugIn == false)
        {
            PowerButton.image.color = Color.black;
            OffScreen.transform.gameObject.SetActive(true);
            OnScreen.transform.gameObject.SetActive(false);
        }
    }
}
