using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void playButtonOnCLick()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void optionsButtonOnCLick()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
  }

  public void helpButtonOnCLick()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
  }

  public void aboutButtonOnCLick()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
  }

  public void backButtonOnCLick()
  {
    SceneManager.LoadScene(0);
  }

}