using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AsteroidRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private Vector3 rotationAxis = new Vector3(0.2f, 1f, 0.1f);

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private bool isGrabbed = false;
    private Rigidbody rb;
    private Transform originalParent;  // Store the original parent

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;  // Save the original parent
    }

    private void OnEnable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }
    }

    private void OnDisable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }

    private void Update()
    {
        if (!isGrabbed)
        {
            transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        rb.isKinematic = false;  // Allow movement
        transform.SetParent(null);  // Detach from the original parent to prevent snapping
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        rb.isKinematic = true;  // Make stationary to prevent movement
        transform.SetParent(originalParent, true);  // Reattach to the original parent but keep the new position
    }
}
