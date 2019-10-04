﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 8f;
    [SerializeField]
    private float dashVelocity = 16f;
    [SerializeField]
    private float maxTimeDashing = .5f;
    [SerializeField]
    private float resetDashTime = 3f;
    [SerializeField]
    private GameObject body;
    [SerializeField]
    private LayerMask wallLayerMask;

    private bool isDashing;
    private bool canDash;
    private bool isLookingRight;
    private Rigidbody rb;
    private float horizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        isDashing = false;
        canDash = true;
        isLookingRight = true;
    }

    private void Update()
    {
        Movement();
    }

    private void FixedUpdate()
    {
        if (isDashing == false)
        {
            rb.position += new Vector3(horizontal, 0f);
        }
    }

    private void LateUpdate()
    {
        // if == 0, stays the same as it was
        if (horizontal > 0)
        {
            isLookingRight = true;
            body.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (horizontal < 0)
        {
            isLookingRight = false;
            body.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            canDash = false;
            isDashing = true;
            horizontal = 0f;
            StartCoroutine(Dash());
        }

        if (isDashing == false)
        {
            // not dashing so we can move
            horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        }
    }

    private IEnumerator Dash()
    {
        float velocity = isLookingRight ? dashVelocity : -dashVelocity;
        rb.velocity = new Vector3(velocity, 0f);

        yield return new WaitForSeconds(maxTimeDashing);

        rb.velocity = Vector3.zero;
        isDashing = false;
        StartCoroutine(ResetDash());
    }

    private IEnumerator ResetDash()
    {
        yield return new WaitForSeconds(resetDashTime);
        canDash = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == wallLayerMask)
        {
            horizontal = 0;
        }
    }
}