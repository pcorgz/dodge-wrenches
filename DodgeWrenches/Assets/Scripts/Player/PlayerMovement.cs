using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float dashVelocity = 16f;
    [SerializeField]
    private float maxTimeDashing = .5f;
    [SerializeField]
    private GameObject body = null;
    [SerializeField]
    private LayerMask wallLayerMask = 0;
    [SerializeField]
    Animator animator = null;

    private bool isDashing;
    private bool isLookingRight;
    private Rigidbody rb;
    private PlayerStats playerStats;
    private float horizontal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Start()
    {
        isDashing = false;
        isLookingRight = true;
    }

    private void Update()
    {
        if (GameManager.isGameOver) return;

        Movement();
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
        animator.SetBool("isRunning", horizontal != 0);
        // if == 0, stays the same as it was
        if (horizontal > 0)
        {
            isLookingRight = true;
            body.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        else if (horizontal < 0)
        {
            isLookingRight = false;
            body.transform.rotation = Quaternion.Euler(0f,  -90f, 0f);
        }
    }

    private void Movement()
    {
        // Press space + canDash + Status == Normal
        if (Input.GetKeyDown(KeyCode.Space) 
                && playerStats.CanDash 
                && playerStats.Status == PlayerStats.PlayerStatus.Normal)
        {
            playerStats.CanDash = false;
            isDashing = true;
            horizontal = 0f;
            //DashMeter.DashMeterBar.transform.localScale = new Vector3(0f, 1f, 1f);
            StartCoroutine(Dash());
        }

        if (isDashing == false)
        {
            // not dashing so we can move
            horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * playerStats.MoveSpeed;
        }
    }

    private IEnumerator Dash()
    {
        playerStats.SetDashStatus();
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
        playerStats.SetNormalStatus();
        yield return new WaitForSeconds(playerStats.ResetDashTime);
        playerStats.CanDash = true;
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
