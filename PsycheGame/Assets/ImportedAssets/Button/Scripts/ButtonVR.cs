using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ButtonVR : MonoBehaviour
{
    [Header("Button Settings")]
    public GameObject buttonVisual; // The visual button that moves when pressed
    public UnityEvent onPress; // Optional events for additional behavior
    public UnityEvent onRelease; // Optional events for additional behavior
    public AsteroidLandingController asteroid;

    private AudioSource sound;
    private bool isPressed = false;
    public bool isUnlocked;
    public bool isLandButton;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        if (isLandButton) { isUnlocked = false; }
    }

    // This function is called when the button is pressed
    public void PressButton()
    {
        if (!isPressed && isUnlocked)
        {
            buttonVisual.transform.localPosition = new Vector3(0, 0.003f, 0); // Simulate button press
            onPress.Invoke(); // Invoke events
            if (sound != null)
            {
                sound.Play();
            }
            if (isLandButton)
            {
                winSequence();
            }
            isPressed = true;
        }
    }

    // This function is called when the button is released
    public void ReleaseButton()
    {
        if (isPressed)
        {
            buttonVisual.transform.localPosition = new Vector3(0, 0.015f, 0); // Simulate button release
            onRelease.Invoke(); // Invoke events
            isPressed = false;
        }
    }
    public void SetUnlocked(bool unlocked)
    {
        isUnlocked = unlocked;
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Win Screen"); 
    }
    public void winSequence()
    {
        StartCoroutine(PlayLandingAndSwitchScene());
    }

    private IEnumerator PlayLandingAndSwitchScene()
    {
        // Start the landing animation
        asteroid.GetComponent<AsteroidLandingController>().StartLanding();

        // Wait for the duration of the landing animation
        yield return new WaitForSeconds(asteroid.GetComponent<AsteroidLandingController>().duration);

        // Now load the win screen
        SceneManager.LoadScene("Win Screen");
    }
}
