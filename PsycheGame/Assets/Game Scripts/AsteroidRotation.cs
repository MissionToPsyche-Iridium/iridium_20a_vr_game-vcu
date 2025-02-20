using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f; // Degrees per second
    [SerializeField] private Vector3 rotationAxis = new Vector3(0.2f, 1f, 0.1f); // Slight tilt

    private void Update()
    {
        // Normalize the axis so it always rotates evenly
        transform.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime);
    }
}
