using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private static TextMeshProUGUI scoreText;
    private static string currentScene;
    public static GameOverScreen instance;

    public void Awake()
    {
        instance = this;
        // DontDestroyOnLoad(this.gameObject);
    }
    public static void Setup(int score, string scene)
    {
        currentScene = scene;
        //gameObject.SetActive(true);
        SceneManager.LoadScene("GameOver");
        scoreText.text = "SCORE: " + score.ToString() + " POINTS";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(currentScene);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
