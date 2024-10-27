using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAgainButton : MonoBehaviour
{

  public void RestartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void Quit()
  {
    Debug.LogWarning("Exiting the game!");
    // Application.Quit();
    SceneManager.LoadScene(0);

  }

  public void StartGame()
  {
    SceneManager.LoadScene(0);
  }
}

