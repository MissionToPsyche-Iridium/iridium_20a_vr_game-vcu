using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject numButtons;
    public bool answerCorrect;
    public string correctCode;
    void Start()
    {
        answerCorrect = false;
    }

    public void InsertChar(string c)
    {
        inputField.text += c;
    }

    public void DeleteChar()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }

    public bool checkCode()
    {
        if (inputField.text.Equals(correctCode))
        {
            return true;
        }
        return false;
    }
}
