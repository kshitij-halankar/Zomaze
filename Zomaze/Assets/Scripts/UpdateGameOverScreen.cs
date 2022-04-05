using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGameOverScreen : MonoBehaviour
{
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + GameOverScreen.finalScore.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
