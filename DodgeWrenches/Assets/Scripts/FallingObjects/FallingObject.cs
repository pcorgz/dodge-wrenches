using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallingObject : MonoBehaviour
{
    [SerializeField]
    private float minFallingVelocity = 0f;
    [SerializeField]
    private float maxFallingVelocity = 0f;

    private Rigidbody rb;
    private FallingObjectData fallingData;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float fallingVelocity = Random.Range(minFallingVelocity, maxFallingVelocity);

        fallingData = new FallingObjectData(fallingVelocity);
        rb.velocity = new Vector3(fallingData.GetHorizontalVelocity(), fallingData.GetFallingVelocity());
    }
}
