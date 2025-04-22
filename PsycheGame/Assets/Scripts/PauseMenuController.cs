using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public InputActionAsset inputActions;

    private InputAction pauseAction;
    private bool isPaused = false;

    void Start()
    {
        var pauseMap = inputActions.FindActionMap("PauseMenu");
        pauseAction = pauseMap.FindAction("Pause");

        pauseAction.performed += ctx => TogglePause();
        pauseAction.Enable();

        pauseMenuUI.SetActive(false);
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
