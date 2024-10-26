using TMPro;
using UnityEngine;

public class LivesCounter : MonoBehaviour
{

    [SerializeField] private TMP_Text livesCounter;

    public void UpdateLivesCounter(int lives)
    {
        livesCounter.text = "Lives: x" + lives;
    }
}
