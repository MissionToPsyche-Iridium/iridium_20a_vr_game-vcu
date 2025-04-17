using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Countdown : MonoBehaviour {

    public float totalTime = 180;
    public TextMeshPro timerText;
    public bool timerRunning = true;

    void Update() {
        if(timerRunning)
        {
            if (totalTime > 0) 
            {
                totalTime -= Time.deltaTime;
                float minutes = Mathf.FloorToInt(totalTime / 60);
                float seconds = Mathf.FloorToInt(totalTime % 60);
                timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
            } 
            else 
            {
                totalTime = 0;
                timerRunning = false;
                SceneManager.LoadScene("Failed Screen");
            }
        }
    }
    public void StopTimer()
    {
        timerRunning = false;
    }
}
