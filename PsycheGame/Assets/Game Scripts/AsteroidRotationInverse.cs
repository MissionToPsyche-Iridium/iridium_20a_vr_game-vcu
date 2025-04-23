using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(Rigidbody), typeof(XRGrabInteractable))]
public class AsteroidRotationInverse : MonoBehaviour
{
    [Tooltip("How much to amplify controller tilt into asteroid rotation.")]
    public float rotationSensitivity = 2f;
    [Tooltip("Multiplier for how much spin speed is carried over on release.")]
    public float spinRetention = 1f;

    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    private bool isGrabbed;
    private Quaternion lastRotation;
    private Transform interactor;
    private Quaternion lastTiltOnlyDelta = Quaternion.identity;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.angularDrag = 0.15f;
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
        if (!isGrabbed || interactor == null) return;

        Quaternion currentRot = interactor.rotation;
        Quaternion delta = currentRot * Quaternion.Inverse(lastRotation);

        // Remove twist around forward axis
        Vector3 forward = interactor.forward;
        Quaternion twist = ExtractTwist(delta, forward);
        Quaternion tiltOnly = delta * Quaternion.Inverse(twist);

        // Amplify tilt
        Quaternion amplified = Quaternion.Slerp(Quaternion.identity, tiltOnly, rotationSensitivity);

        // Apply inverted
        transform.rotation = Quaternion.Inverse(amplified) * transform.rotation;

        // Store for spin retention
        lastTiltOnlyDelta = amplified;

        lastRotation = currentRot;
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        rb.isKinematic = true;
        interactor = args.interactorObject.transform;
        lastRotation = interactor.rotation;
        lastTiltOnlyDelta = Quaternion.identity;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        interactor = null;

        // Compute angular velocity from last tilt delta
        // angle-axis representation
        lastTiltOnlyDelta.ToAngleAxis(out float angleDeg, out Vector3 axis);
        if (angleDeg > 0.01f)
        {
            // convert degrees/frame to radians/second
            float angleRad = angleDeg * Mathf.Deg2Rad;
            Vector3 angVel = -axis.normalized * (angleRad / Time.deltaTime) * spinRetention;
            rb.isKinematic = false;
            rb.angularVelocity = angVel;
        }
        else
        {
            rb.isKinematic = false;
        }
    }

    // Extracts the twist component around 'axis'
    private static Quaternion ExtractTwist(Quaternion q, Vector3 axis)
    {
        Vector3 ra = new Vector3(q.x, q.y, q.z);
        Vector3 proj = Vector3.Project(ra, axis.normalized);
        Quaternion twist = new Quaternion(proj.x, proj.y, proj.z, q.w);
        return twist.normalized;
    }
}
