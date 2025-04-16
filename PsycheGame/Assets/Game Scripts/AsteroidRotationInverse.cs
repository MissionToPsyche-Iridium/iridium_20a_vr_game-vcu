using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Rigidbody), typeof(XRGrabInteractable))]
public class AsteroidRotationInverse : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    private bool isGrabbed = false;
    private Quaternion lastRotation;
    private Transform currentInteractorTransform;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.angularDrag = 0.05f;
        grabInteractable.movementType = XRGrabInteractable.MovementType.VelocityTracking;
    }

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    void Update()
    {
        if (isGrabbed && currentInteractorTransform != null)
        {
            Quaternion currentRotation = currentInteractorTransform.rotation;
            Quaternion deltaRotation = currentRotation * Quaternion.Inverse(lastRotation);

            // Invert the delta rotation
            Quaternion invertedDelta = Quaternion.Inverse(deltaRotation);
            transform.rotation = invertedDelta * transform.rotation;

            lastRotation = currentRotation;
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        rb.isKinematic = true; // Using manual rotation, so don't want physics interfering
        currentInteractorTransform = args.interactorObject.transform;
        lastRotation = currentInteractorTransform.rotation;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        currentInteractorTransform = null;
        rb.isKinematic = true;
    }
}
