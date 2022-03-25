using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTime : MonoBehaviour
{
    [SerializeField] GameOverScreen gameOverScreen;
    int maxPlatform  = 0;
    private float currentTime = 0f;
    [SerializeField] private float startingTime;
    private TimeSpan timePlaying;
    [SerializeField] TextMeshProUGUI gameTime;
    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        gameTime.color = Color.green;
        gameTime.text = "00:00";
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(currentTime);
        //print(currentTime);
        if (currentTime < 20)
        {
            gameTime.color = Color.red;
        } else
        {
            gameTime.color = Color.green;
        }
        gameTime.text = timePlaying.ToString("mm':'ss");

        if (currentTime <= 0)
        {
            currentTime = 0;
            if (!isGameOver)
            {
                isGameOver = true;
                GameOver();
            }
        }
    }
    public void GameOver()
    {
        gameOverScreen.Setup(10);
    }

    public float getCurrentTime(){
        return currentTime;
    }

    public float getStartingTime(){
        return startingTime;
    }
}
