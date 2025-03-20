using UnityEngine;
using System.Collections;

public class LightChanger : MonoBehaviour
{
    public Keyboard codeChecker;  // Reference to the code checker script
    public Renderer cubeRenderer;    // Renderer of the cube
    public Material correctMaterial; // Material when the code is correct
    public Material incorrectMaterial; // Material for blinking red
    private Material originalMaterial; // Stores the default material

    private void Start()
    {
        // Save the original material so we can revert back
        if (cubeRenderer != null)
        {
            originalMaterial = cubeRenderer.material;
        }
    }

    private void Update()
    {
        if (codeChecker != null)
        {
            if (codeChecker.answerCorrect)
            {
                // Set to green and stay there
                cubeRenderer.material = correctMaterial;
            }
            else
            {
                // Start blinking red twice, then revert
                StartCoroutine(BlinkRedTwice());
            }
        }
    }

    private IEnumerator BlinkRedTwice()
    {
        // Blink red twice
        for (int i = 0; i < 2; i++)
        {
            cubeRenderer.material = incorrectMaterial;
            yield return new WaitForSeconds(0.3f); // Red for 0.3s
            cubeRenderer.material = originalMaterial;
            yield return new WaitForSeconds(0.3f); // Back to normal for 0.3s
        }
    }
}
