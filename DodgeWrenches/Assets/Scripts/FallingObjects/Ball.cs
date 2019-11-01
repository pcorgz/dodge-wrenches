using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.right * 200f + Vector3.up * 200f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int soundIx = Random.Range(1, 5);
        string bounceSound = $"Bounce_{soundIx}";
        AudioManager.instance.Play(bounceSound);
    }
}
