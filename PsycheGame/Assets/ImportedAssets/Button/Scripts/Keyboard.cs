using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Keyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject numButtons;
    public bool answerCorrect;
    public string correctCode;
    public GameObject answerLight;

    // For code light
    public Material correctMaterial; // Material when the code is correct
    public Material incorrectMaterial; // Material for blinking red
    private Material originalMaterial; // Stores the default material

    void Start()
    {
        answerCorrect = false;
        originalMaterial = answerLight.GetComponent<Renderer>().material; // Store the original material at start
    }

    public void InsertChar(string c)
    {
        if (inputField.text.Length < 4)
        {
            inputField.text += c;
        }
    }

    public void DeleteChar()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }

    private void checkCode()
    {
        answerCorrect = inputField.text.Trim() == correctCode.Trim();
    }

    public void PressEnter()
    {
        checkCode();
        inputField.text = "";

        Renderer lightRenderer = answerLight.GetComponent<Renderer>();

        if (answerCorrect)
        {
            //Correct code: Turn green
            lightRenderer.material = correctMaterial;
            SceneManager.LoadScene(8);
        }
        else
        {
            //Incorrect code: Turn red
            lightRenderer.material = incorrectMaterial;
        }

        //Reset to original material after 0.5 seconds
        Invoke(nameof(ResetLight), 0.5f);
    }

    void ResetLight()
    {
        answerLight.GetComponent<Renderer>().material = originalMaterial;
    }
}
