using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayFunctionality : MonoBehaviour {
    public void HowToPlay(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
