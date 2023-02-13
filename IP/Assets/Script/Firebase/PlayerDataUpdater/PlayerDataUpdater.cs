using UnityEngine;
using Firebase.Auth;

public class PlayerDataUpdater : MonoBehaviour
{
    [Header("Firebase Objects")]
    public PlayerStatesDB PSDB;
    FirebaseUser user;
    FirebaseAuth auth;

    [Header("SunLogic")]
    public SunLogic SunLogic;

    [Header("Count Timer Adder")]
    public int CountTimerAdder;

    public bool isChecked;

    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

    public void UpdatePlayerStates(int TimeCount)
    {
        PSDB.UpdatePlayerStats(auth.CurrentUser.UserId, TimeCount, 0);
    }

    private void SunSetCount()
    {
        if (SunLogic.timeCount == "00:00")
        {
            isChecked = true;

            if (isChecked)
            {
                CountTimerAdder += 1;
                Debug.Log("Counter " + CountTimerAdder);
                UpdatePlayerStates(CountTimerAdder);
            }
            isChecked = false;
        }

    }

    private void FixedUpdate()
    {
        SunSetCount();
    }
}
