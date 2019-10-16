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
    private float fallingVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        fallingVelocity = Random.Range(minFallingVelocity, maxFallingVelocity);
        rb.velocity = new Vector3(0f, fallingVelocity);
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.y < fallingVelocity
                ? new Vector3(0f, fallingVelocity)
                : rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            int rand = Random.Range(1, 4);

            AudioManager.instance.Play($"Hit_{rand}");
        }
    }
}
