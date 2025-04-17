using System;
using Unity.VisualScripting;
using UnityEngine;

public class FlipSwitch : MonoBehaviour
{
    public int switchPosition = 0;  // 0 for left, 1 for right
    public Transform switchHandle;  // Reference to the switch handle's transform (you'll assign this in the inspector)

    private Quaternion leftRotation;  // Left position rotation
    private Quaternion rightRotation; // Right position rotation
    public AudioSource sound;


    public Boolean flippable;

    private void Start()
    {
        // Set the left position to the switch's current rotation at the start
        leftRotation = switchHandle.rotation;

        // Set the right position to the left position's Y rotation minus 100 degrees
        rightRotation = Quaternion.Euler(leftRotation.eulerAngles.x, leftRotation.eulerAngles.y - 100, leftRotation.eulerAngles.z);

        // Ensure the switch starts in the left position (it should be already, but just in case)
        switchHandle.rotation = leftRotation;
        flippable = true;
    }

    public void Flip()
    {
        if (flippable)
        {
            if (switchPosition == 0)
            {
                // Flip to the right position
                switchHandle.rotation = rightRotation;
                switchPosition = 1;  // Update switch position value
            }
            else
            {
                // Flip to the left position
                switchHandle.rotation = leftRotation;
                switchPosition = 0;  // Update switch position value
            }
                sound.Play();

        }

    }
}
