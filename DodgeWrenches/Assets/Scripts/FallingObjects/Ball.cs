using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerStats playerStats;
    private bool canDebuff = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnEnable()
    {
        canDebuff = true;
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.right * 200f + Vector3.up * 200f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int soundIx = Random.Range(1, 5);
        string bounceSound = $"Bounce_{soundIx}";
        AudioManager.instance.Play(bounceSound);

        if (canDebuff && collision.gameObject.CompareTag(PlayerStats.PLAYER_TAG))
        {
            canDebuff = false;
            playerStats.SlowDown(0.5f, 2f);
            StartCoroutine(GameManager.DisableGameObject(gameObject, 0.5f));
        }
    }
}
