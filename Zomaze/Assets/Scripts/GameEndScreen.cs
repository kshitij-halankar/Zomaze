using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameEndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private string currentScene;
    public void Setup(int score) {
        //gameObject.SetActive(true);
        SceneManager.LoadScene("GameExit");
        scoreText.text = "SCORE: " + score.ToString() + " POINTS";
    }

    public void MainMenuButton() {
        SceneManager.LoadScene("StartMenu");
    }
}
