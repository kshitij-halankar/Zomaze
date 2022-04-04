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

    //public UploadScore uploadScore;

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
        //updateScore(2);

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

    public void updateScore(int score) {
        Debug.Log("Updating Score");
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "HighScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    public void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result) {
        Debug.Log("Score Updated");
    }

    public void OnError(PlayFabError error) {
        Debug.Log("Score Update Fail");
    }

    public void GoToSignUpPage() {
        SceneManager.LoadScene("SignupPage");
    }

    public void GetLeaderBoard() {
        var request = new GetLeaderboardRequest {
            StatisticName = "HighScore",
            StartPosition = 0,
            MaxResultsCount = 5
        };

        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);


    }

    void OnLeaderboardGet(GetLeaderboardResult result) {

    }
}
