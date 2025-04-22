using UnityEngine;

public class SwitchTextOnBool : MonoBehaviour
{
    public GameObject controllerObject; // Object with the SwitchesAllCorrect script
    private SwitchesAllCorrect controllerScript;

    public GameObject textToDisable;
    public GameObject textToEnable;

    private AudioSource audioSource;
    private bool hasSwitched = false; // Ensure it only triggers once

    void Start()
    {
        if (controllerObject != null)
        {
            controllerScript = controllerObject.GetComponent<SwitchesAllCorrect>();
        }

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!hasSwitched && controllerScript != null && controllerScript.switchesCorrect)
        {
            hasSwitched = true;

            if (textToDisable != null)
                textToDisable.SetActive(false);

            if (textToEnable != null)
                textToEnable.SetActive(true);

            if (audioSource != null)
                audioSource.Play();
        }
    }
}
