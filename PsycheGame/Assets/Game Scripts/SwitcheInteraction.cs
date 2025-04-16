using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SwitcheInteraction : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public PanelUnscrew boxDoor;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.enabled = false;
    }

    void Update()
    {
        if (grabInteractable.enabled == false)
        {
            if (boxDoor.doorOpen)
            {
                grabInteractable.enabled = true;
            }
            else
            {
                grabInteractable.enabled = false;
            }
        }
    }
}
