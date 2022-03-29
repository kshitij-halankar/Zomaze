using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

using PlayFab;
using PlayFab.ClientModels;

public class LoginScript : MonoBehaviour
{
    public TMP_InputField email;
    public TMP_InputField userPassword;

    //public GameObject userName, userEmail, userPassword;
    string encryptedPassword;

    public void Login()
    {
        var LoginRequest = new LoginWithEmailAddressRequest
        {
            Email = email.text,
            Password = Encrypt(userPassword.text)
        };

        //PlayFabClientAPI.RegisterPlayFabUser(LoginRequest, OnRegisterRequestSuccess, OnRegisterFailure);
        PlayFabClientAPI.LoginWithEmailAddress(LoginRequest, OnLoginSuccess, OnLoginFailure);

        //Debug.Log(
        //   userName.text + " "
        //    + userEmail.text + " "
        //    + userPassword.text
        // );

    }

    public void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("User Logged In");
        SceneManager.LoadScene("Level1");
    }

    public void OnLoginFailure(PlayFabError error)
    {
        Debug.Log("Login Failed");
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
}
