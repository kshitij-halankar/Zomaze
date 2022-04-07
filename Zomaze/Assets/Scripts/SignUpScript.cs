using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

using PlayFab;
using PlayFab.ClientModels;

public class SignUpScript : MonoBehaviour
{
    public TMP_InputField userName;
    public TMP_InputField userEmail;
    public TMP_InputField userPassword;

    //public GameObject userName, userEmail, userPassword;
    string encryptedPassword;

   public void SignUp(){
        var registerRequest = new RegisterPlayFabUserRequest
        {
            Username = userName.text,
            Email = userEmail.text,
            Password = Encrypt(userPassword.text),
            DisplayName = userName.text
        };

        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterRequestSuccess, OnRegisterFailure);

        //Debug.Log(
        //   userName.text + " "
        //    + userEmail.text + " "
        //    + userPassword.text
        // );

    }

    public void OnRegisterRequestSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("User Registered");
        SceneManager.LoadScene("LoginPage");
    }

    public void OnRegisterFailure(PlayFabError error)
    {
        Debug.Log("Registeration Failed");
        Debug.Log(error.ErrorMessage);
    }

    string Encrypt(string pw)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] epw = System.Text.Encoding.UTF8.GetBytes(pw);
        epw = x.ComputeHash(epw);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (byte b in epw)
        {
            s.Append(b.ToString("x2").ToLower());
        }
        return s.ToString();
    }

    public void GoToLoginPage() {
        SceneManager.LoadScene("LoginPage");
    }
}
