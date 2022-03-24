using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "SCORE: " + score.ToString() + " POINTS";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level3");
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
