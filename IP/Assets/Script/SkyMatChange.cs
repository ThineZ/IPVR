using UnityEngine;

public class SkyMatChange : MonoBehaviour
{
    [Header("Sky Material")]
    public Material[] SkyMat;

    [Header("SunLogic")]
    public SunLogic SunLogic;

    private void ChangeSkyMat()
    {
        if (SunLogic.timeCount == "21:00")
        {
            GameObject.Find("sky").GetComponent<MeshRenderer>().material = SkyMat[0];
        }
        else if(SunLogic.timeCount == "07:00")
        {
            GameObject.Find("sky").GetComponent<MeshRenderer>().material = SkyMat[1];
        }
    }

    private void Update()
    {
        ChangeSkyMat();
    }
}
