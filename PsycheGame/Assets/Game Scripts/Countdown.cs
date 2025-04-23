using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float totalTime = 180f;
    public TextMeshPro timerText;
    public bool timerRunning = true;

    private AudioSource audioSource;
    private int lastSecondPlayed = -1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!timerRunning)
            return;

        if (totalTime > 0f)
        {
            totalTime -= Time.deltaTime;
            if (totalTime < 0f)
                totalTime = 0f;

            // Update display
            int minutes = Mathf.FloorToInt(totalTime / 60f);
            int seconds = Mathf.FloorToInt(totalTime % 60f);
            timerText.text = string.Format("{0}:{1:00}", minutes, seconds);

            // If in last 10 seconds, trigger audio each whole second
            if (totalTime <= 10f)
            {
                int currentSecond = Mathf.CeilToInt(totalTime);
                if (currentSecond != lastSecondPlayed && currentSecond > 0)
                {
                    lastSecondPlayed = currentSecond;
                    if (audioSource != null)
                        audioSource.Play();
                }
            }
        }
        else
        {
            timerRunning = false;
            SceneManager.LoadScene("Failed Screen");
        }
    }

    public void StopTimer()
    {
        timerRunning = false;
    }
}
