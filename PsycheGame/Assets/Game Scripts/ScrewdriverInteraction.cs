using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ScrewdriverInteraction : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public GameObject safeDoor;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void Update()
    {
        if(grabInteractable.enabled == false)
        {
            if (safeDoor != null && safeDoor.GetComponent<SafeDoorOpener>().isOpening)
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
