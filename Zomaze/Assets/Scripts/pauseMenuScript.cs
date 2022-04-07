using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseMenuScript : MonoBehaviour
{
    private Sprite soundOnImage;
    public Sprite soundOffImage;
    public Button button;
    private bool isOn = true;
    public AudioSource audioSocure;
    public AudioSource audioSocure1;
    public AudioSource audioSocure2;
    void Start()
    {
        soundOnImage = button.image.sprite; 
    }

    public void ButtonClicked()
    {
        if(isOn)
        {
            button.image.sprite = soundOffImage;
            isOn = false;
            audioSocure.mute = true;
            audioSocure1.mute = true;
            audioSocure2.mute = true;
        }

        else
        {
            button.image.sprite = soundOnImage;
            isOn = true;
            audioSocure.mute = false;
            audioSocure1.mute = false;
            audioSocure2.mute = false;
        }
    }

    public GameObject PauseMenu;
    public void PauseMenuFunction()
    {
        if(Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }

        PauseMenu.SetActive(true);
    }

    public void ResumeMenuFunction()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }

        PauseMenu.SetActive(false);
    }

    public void QuitFunction()
    {
        //Application.Quit();
        SceneManager.LoadScene("MainMenu");
    }
}
 