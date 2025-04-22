using UnityEngine;

public class AsteroidLandingController : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(13f, -22f, -7f);
    public Vector3 targetRotationEuler = new Vector3(85f, 12f, 124f);
    public float duration = 5f;

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private float timer = 0f;
    private bool isLanding = false;

    private AudioSource audioSource;

    void Start()
    {
        // Set initial positions and rotations
        startPosition = transform.position;
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(targetRotationEuler);

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isLanding)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);

            // Smooth interpolation
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);

            // Optional: stop when done
            if (t >= 1f)
                isLanding = false;
        }
    }

    // Call this to start the movement and play audio
    public void StartLanding()
    {
        timer = 0f;
        startPosition = transform.position;
        startRotation = transform.rotation;
        isLanding = true;

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
