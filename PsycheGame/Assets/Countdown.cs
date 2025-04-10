using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Countdown : MonoBehaviour {

    public float totalTime = 180;
    public TextMeshProUGUI timerText;

    void Update() {
        if (totalTime > 0) {
            totalTime -= Time.deltaTime;
            float minutes = Mathf.FloorToInt(totalTime / 60);
            float seconds = Mathf.FloorToInt(totalTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        } 
        else {
            totalTime = 0;
            SceneManager.LoadScene(5);
        }
    }
}
