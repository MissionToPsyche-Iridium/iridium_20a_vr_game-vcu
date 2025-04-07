using System.Collections;
using UnityEngine;

public class SafeDoorOpener : MonoBehaviour
{
    public float openSpeed = 1.5f; 
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    public bool isOpening = false;

    void Start()
    {
        initialRotation = transform.localRotation;
        targetRotation = Quaternion.Euler(0f, -100f, 0f);
    }

    public void OpenSafeDoor()
    {
        if (!isOpening)
        {
            StartCoroutine(RotateDoor());
        }
    }

    private IEnumerator RotateDoor()
    {
        isOpening = true;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * openSpeed;
            transform.localRotation = Quaternion.Lerp(initialRotation, targetRotation, elapsedTime);
            yield return null;
        }

        transform.localRotation = targetRotation;
        isOpening = false;
    }
}
