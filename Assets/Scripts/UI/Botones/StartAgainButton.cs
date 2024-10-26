using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAgainButton : MonoBehaviour
{
    
    public void RestartGame(){
    
  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit(){
    Application.Quit();
    }

    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

