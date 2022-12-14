using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Stopwatch : MonoBehaviour
{
    public static bool stopwatchActive = false;
    float currentTime;
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI bestTimeText;
    public float bestTime = 0;
    private bool firstScore = true;

    // Start is called before the first frame update
    void Start()
    {
        bestTime = PlayerPrefs.GetFloat("bestTime", bestTime);
        if (bestTime > 0)
        {
            TimeSpan time = TimeSpan.FromSeconds(bestTime);
            bestTimeText.text = "Best: " + time.ToString(@"mm\:ss\:ff");
        }
        else
        {
            bestTimeText.text = "Best:      ---";
        }
        currentTime = 0;
        StartStopwatch();
    }

    // Update is called once per frame
    void Update()
    {
        if(stopwatchActive == true){
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
        if(stopwatchActive == false)
        {
            updateHighScore();
        }
    }

    public void StartStopwatch(){
        stopwatchActive = true;
    }

    public static void StopStopwatch(){
        stopwatchActive = false;
    }
    public void updateHighScore()
    {
        if (firstScore)
        {
            bestTime = currentTime;
            TimeSpan time = TimeSpan.FromSeconds(bestTime);
            bestTimeText.text = "Best: " + time.ToString(@"mm\:ss\:ff");
            PlayerPrefs.SetFloat("bestTime", bestTime);
            firstScore = false;
        }
        if (currentTime < bestTime)
        {
            bestTime = currentTime;
            TimeSpan time = TimeSpan.FromSeconds(bestTime);
            PlayerPrefs.SetFloat("bestTime", bestTime);
            bestTimeText.text = "Best: " + time.ToString(@"mm\:ss\:ff");
        }
    }
}
