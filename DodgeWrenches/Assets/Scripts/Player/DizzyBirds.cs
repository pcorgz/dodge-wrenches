using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DizzyBirds : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = -30f;
    private float newYRotation;

    private void Start()
    {
        newYRotation = 0f;
    }

    private void Update()
    {
        newYRotation += rotationSpeed * Time.deltaTime;
        newYRotation = newYRotation >= 360
                ? 0f
                : newYRotation;

        transform.localRotation = Quaternion.Euler(transform.localRotation.x, newYRotation, transform.localRotation.z);
    }
}
