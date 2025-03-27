using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
  public float totalTime = 180; //Set the total time for the countdown
  public Text timerText;

  void Update()
  {
    if (totalTime > 0)
    {
      // Subtract elapsed time every frame
      totalTime -= Time.deltaTime;

      // Divide the time by 60
      float minutes = Mathf.FloortoInt(totalTime / 60); 
      
      // Returns the remainder
      float seconds = Mathf.FloortoInt(totalTime % 60);

      // Set the text string
      timerText.text = string.Format(“{0:00}:{1:00}”, minutes, seconds);
    }
    else
    {
      SceneManager.LoadScene(5);
      totalTime = 0;
    }
  }
}