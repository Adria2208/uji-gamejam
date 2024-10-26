using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField] private HouseHealth[] houses;

    public int playerLives = 5;

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

}
