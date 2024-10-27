using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField] private HouseHealth[] houses;
    [SerializeField] private Timer timer;
    public GameObject listaCasas;
    public int playerLives = 5;
    public TextMeshProUGUI endText;
    public GameObject victoryText;
    public GameObject loseText;

    public int acitveHouses;
    public int completeHouses;
    //Casas
    public TextMeshProUGUI houseText;


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

    private void Start()
    {
        UIManager.Instance.UpdateLivesCounter(playerLives);
        victoryText.SetActive(false);
        loseText.SetActive(false);
        Time.timeScale = 1;
    }

    public void SubtractLife()
    {
        Debug.Log("Hurting Player");
        playerLives--;
        UIManager.Instance.UpdateLivesCounter(playerLives);
    }

    public int GetCurrentLives()
    {
        return playerLives;
    }
    void Update()
    {

        Victory();
        Defeat();
        Houses();
    }

    //Acabar el juego
    //Completar todas las casas
    public void Victory()
    {
        if (listaCasas.GetComponent<HouseList>().completed == true)
        {
            victoryText.SetActive(true);
            Time.timeScale = 0;
        }
    }
    //Morir
    public void Defeat()
    {
        if (playerLives == 0)
        {
            loseText.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void AddCandy(int candy)
    {
        float time = candy;
        timer.AddTime(time);
    }

    //Contador de casas
    public void Houses()
    {
        acitveHouses = (listaCasas.GetComponent<HouseList>().houses.Count);
        completeHouses = (listaCasas.GetComponent<HouseList>().housesCompleted);

        houseText.SetText("Houses: " + completeHouses.ToString() + "/" + acitveHouses.ToString());
    }

}
