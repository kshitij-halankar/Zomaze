using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private string currentScene;
    public void Setup(int score, string scene)
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
        SceneManager.LoadScene("StartMenu");
    }
}
