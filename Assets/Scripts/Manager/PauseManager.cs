using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]private GameObject PauseMenu;
    [SerializeField]private GameObject Options;
    [SerializeField]private GameObject PauseBlackscreen;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        PauseGame();
        PauseOptions();
        ResumeGame();        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused){
            ResumeGame();
        }
    }

    private void PauseGame(){
        // Time.timeScale = 0f;
        isPaused=true;
        PauseBlackscreen.SetActive(true);
        ComeBackToMenu();
    }

    public void ResumeGame(){
        // Time.timeScale = 1f;
        isPaused=false;
        PauseBlackscreen.SetActive(false);
        PauseMenu.SetActive(false);
        Options.SetActive(false);
    }

    public void LoadLastCheckpoint(){

    }

    public void PauseOptions(){
        PauseMenu.SetActive(false);
        Options.SetActive(true);        
    }
    
    public void ComeBackToMenu(){
        PauseMenu.SetActive(true);
        Options.SetActive(false);  
    }

    public void GoBackToMain(){
        SceneManager.LoadScene("MainMenu");
    }
}
