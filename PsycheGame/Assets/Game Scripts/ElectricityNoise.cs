using UnityEngine;

public class ElectricityNoise : MonoBehaviour
{
    // Reference to the object with the SwitchesAllCorrect script
    public GameObject controllerObject;

    // Reference to the actual script on the controllerObject
    private SwitchesAllCorrect controllerScript;

    void Start()
    {
        if (controllerObject != null)
        {
            controllerScript = controllerObject.GetComponent<SwitchesAllCorrect>();
        }
    }

    void Update()
    {
        if (controllerScript != null && controllerScript.switchesCorrect)
        {
            gameObject.SetActive(false);
        }
    }
}

