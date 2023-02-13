using System;
using UnityEngine;

public class PlayerStatesClass
{
    // Objects
    public string userID;
    public int TimeCount;
    public int EatCount;
    public long updateOn;

    // Empty Construstor
    public PlayerStatesClass() { }

    // Constructor
    public PlayerStatesClass(string userID, int TimeCount, int EatCount)
    {
        this.userID = userID;
        this.TimeCount = TimeCount;
        this.EatCount = EatCount;

        var timestamp = this.GetTimeUnix();
        this.updateOn = timestamp;
    }

    public long GetTimeUnix()
    {
        return new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    }

    public string PlayerStatsToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
