using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playButtonOnCLick()
    {
    SceneManager.LoadScene("LevelSelector");
    }

    public void optionsButtonOnCLick()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void helpButtonOnCLick() {
        SceneManager.LoadScene("Help");
    }

    public void leaderboardButtonOnCLick()
    {
    SceneManager.LoadScene("LeaderBoard");
    }

    public void aboutButtonOnCLick()
    {
    SceneManager.LoadScene("About");
    }

    public void backButtonOnCLick()
    {
    SceneManager.LoadScene("MainMenu");
    }

}