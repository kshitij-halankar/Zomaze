using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenuScript : MonoBehaviour
{
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
        Application.Quit();
    }
}
 