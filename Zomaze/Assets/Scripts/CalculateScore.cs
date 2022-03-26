using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalculateScore : MonoBehaviour
{
    private bool hintUsed = false;
    private int score;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameTime gameTime; 
    [SerializeField] Button hintButton;


    void Start()
    {
        hintButton.onClick.AddListener(TaskOnClick);
        score = 0;
        scoreText.text = "Score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score.ToString();
       
    }

    
    public void keyCollected(){
        float currentTime = gameTime.getCurrentTime();   
        if(currentTime >= gameTime.getStartingTime()/2){
            score = score + 500;
        }
        else if(currentTime >= gameTime.getStartingTime()/4){
            score = score + 250;
        }
        else{
            score = score + 100;
        }
    }

    public void mazeExited(){
        score = score + ((int)gameTime.getCurrentTime()*20);
    }

    public int getScore(){
        return score;
    }

    void TaskOnClick(){
		if(!hintUsed){
            hintButton.GetComponent<Image>().color = Color.red;
            hintUsed = true;
            score = score - 200;
        }
	}


}
