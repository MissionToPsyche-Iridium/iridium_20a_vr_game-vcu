using System;
using UnityEngine;

public class FlipSwitch : MonoBehaviour
{
    public int switchPosition = 0;  // 0 for left, 1 for right
    public Transform switchHandle;  // Reference to the switch handle's transform

    private Quaternion leftRotation;  // Left position rotation
    private Quaternion rightRotation; // Right position rotation

    private AudioSource sound;  // We'll get this at runtime

    public bool flippable;

    private void Start()
    {
        // Cache AudioSource on this GameObject
        sound = GetComponent<AudioSource>();

        leftRotation = switchHandle.rotation;
        rightRotation = Quaternion.Euler(
            leftRotation.eulerAngles.x,
            leftRotation.eulerAngles.y - 100,
            leftRotation.eulerAngles.z);

        switchHandle.rotation = leftRotation;
        flippable = true;
    }

    public void Flip()
    {
        if (flippable)
        {
            if (switchPosition == 0)
            {
                switchHandle.rotation = rightRotation;
                switchPosition = 1;
            }
            else
            {
                switchHandle.rotation = leftRotation;
                switchPosition = 0;
            }

            if (sound != null)
                sound.Play();
        }
    }
}
