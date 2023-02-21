using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerAuth : MonoBehaviour
{
    //Database Reference
    DatabaseReference db;
    DatabaseReference accounts;

    //Firebase Auth
    [Header("Firebase Auth")]
    public FirebaseAuth auth;
    public FirebaseUser user;

    // Register Objects
    [Header("Register UI")]
    public TMP_InputField ResEmail;
    public TMP_InputField ResPassword;
    public TMP_Text AlertDialog;
    public Button SignUp;

    private void Awake()
    {
        //Init the Database
        db = FirebaseDatabase.DefaultInstance.RootReference;

        //Account Database
        accounts = FirebaseDatabase.DefaultInstance.GetReference("PlayerAccounts");

        //Firebase Auth
        auth = FirebaseAuth.DefaultInstance;
    }

    // Create New Accounts into FirebaseDatabase
    private void CreateAccounts(string uuid, string email, string password)
    {
        PlayerClass CreateClass = new PlayerClass(email, password);

        string checkChar = CreateClass.password;

        if (checkChar.Length < 6)
        {
            Debug.Log("Password too short");
        }
        else
        {
            accounts.Child("NewAccountCreated/" + uuid).SetRawJsonValueAsync(CreateClass.PlayerClassToJson());
        }
    }

    public void RegisterFunction()
    {
        StartCoroutine(RegisterLogic(ResEmail.text.Trim(), ResPassword.text.Trim()));
    }

    private IEnumerator RegisterLogic(string ResEmail, string ResPwd)
    {
        if (ResEmail == "")
        {
            // If Email field is empty prompt a warning
            AlertDialog.text = "Missing Email";

        }
        else if (ResPwd == "")
        {
            AlertDialog.text = "Missing Password";
        }
        else
        {
            // Call Firebase auth function to create a new account
            var ResFunc = auth.CreateUserWithEmailAndPasswordAsync(ResEmail, ResPwd);

            yield return new WaitUntil(predicate: () => ResFunc.IsCompleted);

            if (ResFunc.Exception != null)
            {
                // If have errors handle the errors
                FirebaseException exception = ResFunc.Exception.GetBaseException() as FirebaseException;

                AuthError ResError = (AuthError)exception.ErrorCode;

                string output = "Sign Up Error";

                switch (ResError)
                {
                    case AuthError.MissingEmail:
                        output = "Please Enter Your Email";
                        break;
                    case AuthError.MissingPassword:
                        output = "Please Enter Your Password";
                        break;
                    case AuthError.WeakPassword:
                        output = "Password Length too Short, Min 6 Characters";
                        break;
                    case AuthError.EmailAlreadyInUse:
                        output = "Email Aleardy Registered";
                        break;
                }
                AlertDialog.text = output;
            }
            else
            {
                // New User Created
                user = ResFunc.Result;

                // At the same time able to store the User Credentials into Firebase Database with unqie UUID
                CreateAccounts(user.UserId, ResEmail.Trim(), ResPwd.Trim());

                if (user != null)
                {
                    // Create User Profile
                    UserProfile profile = new UserProfile { DisplayName = ResEmail }; 

                    // Call the Firebase auth and update user profiles
                    var ProfileTask = user.UpdateUserProfileAsync(profile);

                    // Wait Function
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null)
                    {
                        // If there are any errors handle the errors
                        Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");

                        FirebaseException exception = ProfileTask.Exception.GetBaseException() as FirebaseException;

                        AuthError errorProfile = (AuthError)exception.ErrorCode;

                        AlertDialog.text = "Account Set Failed";
                    }
                    else
                    {
                        AlertDialog.text = "Sign Up Successfull";

                        LoadedToGame();
                    }
                }
            }
        }
    }

    private void LoadedToGame()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
}