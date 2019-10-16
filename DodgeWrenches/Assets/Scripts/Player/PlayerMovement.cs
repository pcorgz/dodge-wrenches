using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private GameObject body = null;
    [SerializeField]
    private LayerMask wallLayerMask = 0;
    [SerializeField]
    private Image dashMeterBar = null;

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
        if (GameManager.isGameOver) return;

        Movement();
        if (canDash == false)
        {
            dashMeterBar.transform.localScale += new Vector3(Time.deltaTime / resetDashTime, 0f);
            if (dashMeterBar.transform.localScale.x >= 1)
                dashMeterBar.transform.localScale = Vector3.one;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.isGameOver) return;

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
            body.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (horizontal < 0)
        {
            isLookingRight = false;
            body.transform.rotation = Quaternion.Euler(0f,  0f, 0f);
        }
    }

    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            canDash = false;
            isDashing = true;
            horizontal = 0f;
            dashMeterBar.transform.localScale = new Vector3(0f, 1f, 1f);
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
        AudioManager.instance.Play("Dash");
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
            rb.velocity = Vector3.zero;
            horizontal = 0;
        }
    }
}
