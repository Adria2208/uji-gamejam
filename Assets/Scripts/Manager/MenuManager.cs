using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject TitleScreen;
    [SerializeField] private GameObject Main;
    [SerializeField] private GameObject Options;
    private bool TitleMenu;
    void Start()
    {
        TitleMenu=true;
        Options.SetActive(true);
        Main.SetActive(false);
        Options.SetActive(false);
        TitleScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(TitleMenu && Input.anyKey)
        {
        TitleScreen.SetActive(false);
        TitleMenu = false;
        MainMenu();
        }
    }

    public void MainMenu(){
        Main.SetActive(true);
        Options.SetActive(false);
    }

    public void OptionsMenu(){
        Main.SetActive(false);
        Options.SetActive(true);   
    }

    public void NewGame(){
       SceneManager.LoadScene(1);
    }

    public void LoadLastSave(){
        
    }

    public void Quit(){
        Application.Quit();
    }
}
