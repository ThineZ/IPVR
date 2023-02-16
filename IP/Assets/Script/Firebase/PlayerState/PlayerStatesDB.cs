using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;

public class PlayerStatesDB : MonoBehaviour
{
    // Database
    DatabaseReference PSDB;

    FirebaseAuth auth;

    private void Awake()
    {
        InitFirebase();
    }

    private void Start()
    {
        UpdatePlayerStats(auth.CurrentUser.UserId, 0, 0);
    }

    private void InitFirebase()
    {
        PSDB = FirebaseDatabase.DefaultInstance.GetReference("PlayerStates");

        auth = FirebaseAuth.DefaultInstance;
    }

    public void UpdatePlayerStats(string uuid, int TimeCount, int EatCount)
    {
        Query playerQuery = PSDB.Child(uuid);

        // READ the data
        playerQuery.GetValueAsync().ContinueWithOnMainThread(TasksUpdate => 
        {
            if (TasksUpdate.IsFaulted || TasksUpdate.IsCanceled)
            {
                Debug.LogError("");
            }
            else if (TasksUpdate.IsCompleted)
            {
                // If there is an date created check
                DataSnapshot PlayerStatsSnapshot = TasksUpdate.Result;

                if (PlayerStatsSnapshot.Exists)
                {
                    // Udate the Player State
                    // Compare existing data and set new data
                    PlayerStatesClass PSC = JsonUtility.FromJson<PlayerStatesClass>(PlayerStatsSnapshot.GetRawJsonValue());
                    Debug.Log("eat " + EatCount + " time " + TimeCount + " limit " + PSC.TimeCount);
                    Debug.Log(PSC.PlayerStatsToJson());

                    Debug.Log("PSC " + PSC.TimeCount);
                    Debug.Log("PSDB " + TimeCount);

                    // Check if player have eatten
                    if (EatCount != PSC.EatCount)
                    {
                        PSC.EatCount = EatCount;
                    }

                    if (TimeCount != PSC.TimeCount)
                    {
                        PSC.TimeCount = TimeCount;
                    }

                    // Update Overide
                    PSDB.Child(uuid).SetRawJsonValueAsync(PSC.PlayerStatsToJson());
                }
                else
                {
                    // Create Player Stats
                    // If there is no data exist, create one
                    PlayerStatesClass PSC = new PlayerStatesClass(uuid, TimeCount, EatCount);

                    // Add it to Firebase Database
                    PSDB.Child(uuid).SetRawJsonValueAsync(PSC.PlayerStatsToJson());
                }
            }
        });
    }
}
