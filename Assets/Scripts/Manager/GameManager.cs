using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField] private HouseHealth[] houses;
    public GameObject listaCasas;
    public int playerLives = 5;
    public TextMeshProUGUI EndText;
    public GameObject victroyText;
    public GameObject looseText;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            
        }
        else
        {
            Instance = this;
        }
    }

    private void Start() {
        UIManager.Instance.UpdateLivesCounter(playerLives);
        victroyText.SetActive(false);
        looseText.SetActive(false);
        Time.timeScale = 1;
    }

    // public void HouseInteracted(House house){
    //     house.Interact();
    // }


    public void SubtractLife(){
        playerLives--;
        UIManager.Instance.UpdateLivesCounter(playerLives);
    }

    public int GetCurrentLives(){
        return playerLives;
    }
    void Update()
    {
        
        victory();
        Defeat();
    }

    //Acabar el juego
        //Completar todas las casas
    public void victory()
    {
      if (listaCasas.GetComponent<HouseList>().completed == true)
        {
            victroyText.SetActive(true);
            Time.timeScale = 0;
        }  
    }
        //Morir
    public void Defeat()
    {
        if (playerLives == 0)
        {
        
            looseText.SetActive(true);
            Time.timeScale = 0;
        }       
    }

}
