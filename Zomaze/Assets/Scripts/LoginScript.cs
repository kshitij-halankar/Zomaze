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

    [SerializeField] TextMeshProUGUI Row1rank;
    [SerializeField] TextMeshProUGUI Row2rank;
    [SerializeField] TextMeshProUGUI Row3rank;
    [SerializeField] TextMeshProUGUI Row4rank;
    [SerializeField] TextMeshProUGUI Row5rank;
    [SerializeField] TextMeshProUGUI Row1UN;
    [SerializeField] TextMeshProUGUI Row2UN;
    [SerializeField] TextMeshProUGUI Row3UN;
    [SerializeField] TextMeshProUGUI Row4UN;
    [SerializeField] TextMeshProUGUI Row5UN;
    [SerializeField] TextMeshProUGUI Row1Score;
    [SerializeField] TextMeshProUGUI Row2Score;
    [SerializeField] TextMeshProUGUI Row3Score;
    [SerializeField] TextMeshProUGUI Row4Score;
    [SerializeField] TextMeshProUGUI Row5Score;

    //public UploadScore uploadScore;

    //public GameObject userName, userEmail, userPassword;
    string encryptedPassword;

    public void Start() {
        updateScore(25);
        Debug.Log("Script starting");
        if (SceneManager.GetActiveScene().name == "LeaderBoard") {
            Debug.Log("getting leaderboard");
            GetLeaderBoard();
        }
    }

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
        SceneManager.LoadScene("MainMenu");
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
        int i = 1;
        Debug.Log("Leaderboard accessed");
        //Row1.text = "abcd";

        Row1rank.text = "1";
        Row2rank.text = "2";
        Row3rank.text = "3";
        Row4rank.text = "4";
        Row5rank.text = "5";

        foreach (var item in result.Leaderboard) {
            switch (i) {
                case 1:
                    Row1UN.text = item.DisplayName;
                    Row1Score.text = item.StatValue.ToString();
                    break;
                case 2:
                    Row2UN.text = item.DisplayName;
                    Row2Score.text = item.StatValue.ToString();
                    break;
                case 3:
                    Row3UN.text = item.DisplayName;
                    Row3Score.text = item.StatValue.ToString();
                    break;
                case 4:
                    Row4UN.text = item.DisplayName;
                    Row4Score.text = item.StatValue.ToString();
                    break;
                case 5:
                    Row5UN.text = item.DisplayName;
                    Row5Score.text = item.StatValue.ToString();
                    break;

            }
            i++;
        }
    }

    public void LeaderboardBack() {
        SceneManager.LoadScene("MainMenu");
    }
}
