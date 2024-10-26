using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    // [SerializeField] private InteractText interactText;
    [SerializeField] private LivesCounter livesCounter;

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

    // public void SetInteractTextVisible(){
    //     interactText.SetVisible();
    // }

    // public void SetInteractTextInvisible(){
    //     interactText.SetInvisible();
    // }

    public void UpdateLivesCounter(int lives){
        livesCounter.UpdateLivesCounter(lives);
    }

}
