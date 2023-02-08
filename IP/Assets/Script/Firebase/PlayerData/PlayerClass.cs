using UnityEngine;

public class PlayerClass
{
    // Objects
    public string email;
    public string password;

    //Empty Construstor
    public PlayerClass() { }

    //Account Storage Controller
    public PlayerClass(string email, string password)
    {
        this.email = email;
        this.password = password;
    }

    //Helper Function
    public string PlayerClassToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
