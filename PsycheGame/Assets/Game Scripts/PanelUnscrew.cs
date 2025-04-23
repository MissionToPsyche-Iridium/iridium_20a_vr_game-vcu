using UnityEngine;
using System.Collections;

public class PanelUnscrew : MonoBehaviour
{
    public GameObject[] screws;      // Assign all screw GameObjects (children of BoxDoor)
    public GameObject panel;         // Assign the BoxDoor GameObject
    public float unscrewDistance = 0.05f;    // How far screws move along +Z
    public float unscrewTime = 1.5f;         // Time to fully unscrew
    public float rotationSpeed = 360f;       // Rotation speed in degrees/sec

    public bool doorOpen = false;

    private bool isTriggered = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered && other.CompareTag("Screwdriver"))
        {
            isTriggered = true;
            StartCoroutine(UnscrewAndRemove());
        }
    }

    private IEnumerator UnscrewAndRemove()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }

        float elapsedTime = 0f;
        Vector3[] startPositions = new Vector3[screws.Length];

        for (int i = 0; i < screws.Length; i++)
        {
            startPositions[i] = screws[i].transform.localPosition;
        }

        while (elapsedTime < unscrewTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / unscrewTime;

            for (int i = 0; i < screws.Length; i++)
            {
                screws[i].transform.localPosition = startPositions[i] +
                    screws[i].transform.TransformDirection(Vector3.forward) * (unscrewDistance * progress);

                screws[i].transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        foreach (GameObject screw in screws)
        {
            screw.SetActive(false);
        }

        if (panel)
        {
            panel.SetActive(false);
        }

        gameObject.SetActive(false);
        doorOpen = true;
    }
}
