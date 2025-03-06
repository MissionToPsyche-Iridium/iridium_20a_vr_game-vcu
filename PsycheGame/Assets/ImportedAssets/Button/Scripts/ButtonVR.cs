using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRSimpleInteractable))]
public class ButtonVR : MonoBehaviour
{
    [Header("Button Settings")]
    // The visual part of the button that moves when pressed
    public GameObject button;

    // Optional events to hook up extra behavior from the Inspector
    public UnityEvent onPress;
    public UnityEvent onRelease;

    private AudioSource sound;
    private bool isPressed;

    // Reference to the interactable component (XRSimpleInteractable)
    private XRSimpleInteractable simpleInteractable;

    void Awake()
    {
        sound = GetComponent<AudioSource>();
        // Get the interactable component (it must be on the same GameObject)
        simpleInteractable = GetComponent<XRSimpleInteractable>();
        if (simpleInteractable == null)
        {
            Debug.LogWarning("XRSimpleInteractable component not found! Please add it to the button GameObject.");
        }
    }

    void OnEnable()
    {
        // Subscribe to the built-in events
        if (simpleInteractable != null)
        {
            simpleInteractable.selectEntered.AddListener(OnSelectEntered);
            simpleInteractable.selectExited.AddListener(OnSelectExited);
        }
    }

    void OnDisable()
    {
        // Unsubscribe from the events
        if (simpleInteractable != null)
        {
            simpleInteractable.selectEntered.RemoveListener(OnSelectEntered);
            simpleInteractable.selectExited.RemoveListener(OnSelectExited);
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!isPressed)
        {
            PressButton();
        }
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        if (isPressed)
        {
            ReleaseButton();
        }
    }

    private void PressButton()
    {
        // Move the button to simulate a press
        button.transform.localPosition = new Vector3(0, 0.003f, 0);
        onPress.Invoke();
        if (sound != null)
        {
            sound.Play();
        }
        isPressed = true;
    }

    private void ReleaseButton()
    {
        // Reset the button position to simulate a release
        button.transform.localPosition = new Vector3(0, 0.015f, 0);
        onRelease.Invoke();
        isPressed = false;
    }

    public void SpawnSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        sphere.transform.localPosition = new Vector3(0, 1, 2);
        sphere.AddComponent<Rigidbody>();
    }
}
