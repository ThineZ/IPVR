using UnityEngine;
using UnityEngine.UI;

public class Fireboard : MonoBehaviour
{
    [Header("Fire Rod")]
    public GameObject FireRod;

    [Header("LoaderUI")]
    public Slider LoaderSlider;

    [Header("LoaderFill")]
    public Image FillImage;

    [Header("Counter for Rotation")]
    [SerializeField] private int CounterRotation;

    [Header("Fire VFX")]
    public ParticleSystem Fire;

    private Vector3 CurrentPos;
    private Vector3 PreviousPos;

    private float CurrentMotion;
    private float PreviousMotion;

    public bool isRodEntered = false;

    private void Start()
    {
        Fire = GetComponent<ParticleSystem>();
        var StartLiftime = Fire.main.startLifetime;
        StartLiftime.constant = 0;
    }

    private void Update()
    {
        CheckNoMotion();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Rod")
        {
            CurrentPos = FireRod.transform.position;

            Vector3 DiffPos = CurrentPos - PreviousPos;

            CurrentMotion = Vector3.Dot(FireRod.transform.forward, DiffPos);

            if ((CurrentMotion > 0 && PreviousMotion < 0) || (CurrentMotion < 0 && PreviousMotion > 0))
            {
                CounterRotation++;

                Debug.Log("Current Motion " + CurrentMotion);

                if (CounterRotation >= 1)
                {
                    LoaderSlider.value += (float)0.05;

                    if (LoaderSlider.value >= 0.3)
                    {
                        FillImage.color = Color.yellow;

                        if (LoaderSlider.value >= 0.7)
                        {
                            FillImage.color = Color.green;

                            if (LoaderSlider.value == 1)
                            {
                                LoaderSlider.value = 1;
                                // Cast the Fire
                            }
                        }
                    }
                }
                PreviousMotion = CurrentMotion;
                PreviousPos = CurrentPos;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Rod")
        {
            isRodEntered = true;

            PreviousMotion = -1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Rod")
        {
            isRodEntered = false;
        }
    }

    private void CheckNoMotion()
    {
        if (LoaderSlider.value >= 0 && LoaderSlider.value <= 1)
        {
            LoaderSlider.value -= (float)0.5 * Time.deltaTime;
        }
    }
}
