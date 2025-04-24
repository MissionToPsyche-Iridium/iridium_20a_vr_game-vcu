using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public CanvasGroup canvasGroup;
    public InputActionReference pauseAction;
    public Transform playerCamera;
    public LocomotionSystem locomotionSystem;
    public UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationProvider teleportationProvider;

    private bool isPaused = false;
    private Coroutine fadeCoroutine;

    void OnEnable()
    {
        pauseAction.action.performed += OnPause;
        pauseAction.action.Enable();
    }

    void OnDisable()
    {
        pauseAction.action.performed -= OnPause;
        pauseAction.action.Disable();
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        TogglePause();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused && playerCamera != null)
        {
            Vector3 forward = playerCamera.forward;
            forward.y = 0f;
            forward.Normalize();

            pauseMenuCanvas.transform.position = playerCamera.position + forward * 1.5f;
            pauseMenuCanvas.transform.rotation = Quaternion.LookRotation(-forward);
        }

        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);

        fadeCoroutine = StartCoroutine(FadeCanvas(isPaused));
        Time.timeScale = isPaused ? 0f : 1f;

        // Disable movement & teleportation when paused
        if (locomotionSystem != null)
            locomotionSystem.enabled = !isPaused;
        if (teleportationProvider != null)
            teleportationProvider.enabled = !isPaused;
    }

    IEnumerator FadeCanvas(bool show)
    {
        float duration = 0.4f;
        float start = canvasGroup.alpha;
        float end = show ? 1f : 0f;

        pauseMenuCanvas.SetActive(true);

        for (float t = 0; t < duration; t += Time.unscaledDeltaTime)
        {
            canvasGroup.alpha = Mathf.Lerp(start, end, t / duration);
            yield return null;
        }

        canvasGroup.alpha = end;

        if (!show)
            pauseMenuCanvas.SetActive(false);
    }

    public void ResumeGame()
    {
        if (isPaused)
            TogglePause();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title Screen");
    }
}
