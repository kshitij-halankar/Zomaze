using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private static string currentScene;
    public static GameOverScreen instance;
    public static float finalScore;

    public void Awake()
    {
        instance = this;
        // DontDestroyOnLoad(this.gameObject);
    }
    public static void SetupGameOver(int score, string scene)
    {
        finalScore = score;
        currentScene = scene;
        //gameObject.SetActive(true);
        SceneManager.LoadScene("GameOver");
    }

     public static void SetupGameExit(int score, string scene)
    {
        finalScore = score;
        currentScene = scene;
        //gameObject.SetActive(true);
        SceneManager.LoadScene("GameExit");
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(currentScene);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LevelsButton()
    {
        SceneManager.LoadScene("LevelSelector");
    }
}
