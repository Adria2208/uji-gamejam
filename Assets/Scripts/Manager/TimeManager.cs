using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    private float currentTimeFloat = 0.0f;
    public int currentTime = 0;
    private bool waiting;

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
        currentTime = 0;
    }

    private void Update()
    {
        currentTimeFloat += Time.deltaTime;
        currentTime = Mathf.RoundToInt(currentTimeFloat);
    }

    public void Stop(float seconds)
    {
        if (waiting)
        {
            return;
        }
        Time.timeScale = 0.0f;
        StartCoroutine(WaitAndResume(seconds));
    }

    IEnumerator WaitAndResume(float seconds)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 1.0f;
        waiting = false;
    }

}