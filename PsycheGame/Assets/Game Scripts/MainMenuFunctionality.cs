using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctionality : MonoBehaviour {
    public void MainMenu(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
