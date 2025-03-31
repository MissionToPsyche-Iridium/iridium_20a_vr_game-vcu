using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    public FlipSwitch flipSwitch;  // Reference to the FlipSwitch script (assigned in the Inspector)
    public int correctPosition = 0;  // 0 for left, 1 for right (set in Inspector)
    public GameObject lightObject;  // Reference to the light object (assigned in the Inspector)
    public Material correctMaterial; // Material when the switch is in the correct position (green)
    public Material incorrectMaterial; // Material when the switch is in the wrong position (red)

    private Renderer lightRenderer;

    private void Start()
    {
        // Get the light object renderer to change materials
        lightRenderer = lightObject.GetComponent<Renderer>();

        // Update light based on the initial switch position
        UpdateLight();
    }

    private void Update()
    {
        // Continuously check and update the light material based on the current switch position
        UpdateLight();
    }

    private void UpdateLight()
    {
        // Check if the current switch position matches the correct position
        if (flipSwitch.switchPosition == correctPosition)
        {
            lightRenderer.material = correctMaterial; // Green if correct
        }
        else
        {
            lightRenderer.material = incorrectMaterial; // Red if wrong
        }
    }
}
