using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonFunctionality : MonoBehaviour{
    public void StartGame(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
