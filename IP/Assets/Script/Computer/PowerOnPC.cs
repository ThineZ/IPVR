using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class PowerOnPC : MonoBehaviour
{
    [Header("Plug Socket Interactor")]
    [SerializeField] private XRSocketInteractor PlugSocket;
    
    [Header("Power Button")]
    public Button PowerButton;

    [Header("Screen Types")]
    [SerializeField] private Image OffScreen;
    [SerializeField] private Image OnScreen;

    [SerializeField] private bool isPlugIn = false;

    private void Awake()
    {
        PlugSocket = GameObject.Find("PowerAdaptor").GetComponent<XRSocketInteractor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Plug")
        {
            isPlugIn = true;
            PowerButton.image.color = Color.red;
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
        }
        else if (isPlugIn == false)
        {
            PowerButton.image.color = Color.black;
            OffScreen.transform.gameObject.SetActive(true);
            OnScreen.transform.gameObject.SetActive(false);
        }
    }
}
