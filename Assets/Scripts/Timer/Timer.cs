using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Timer : MonoBehaviour
{
    public float secondsRemaining;
    public float defaultCaramelosCount = 300;
    public bool timerIsRunning = false;
    public TMP_Text timeText;

    private void Start()
    {
        secondsRemaining = defaultCaramelosCount;
        timerIsRunning = true;
        timeText = GetComponent<TMP_Text>();

    }

    void Update()
    {
        if (timerIsRunning && secondsRemaining > 0)
        {
            secondsRemaining -= Time.deltaTime;
            DisplayTime(secondsRemaining);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        int timeToDisplayInt = (int)Math.Round(timeToDisplay);
        timeText.text = "Candy: " + timeToDisplayInt;
    }

    public void ResetTimer()
    {
        secondsRemaining = defaultCaramelosCount;
        timerIsRunning = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    public void AddTime(float time){
        secondsRemaining += time;
    }
}