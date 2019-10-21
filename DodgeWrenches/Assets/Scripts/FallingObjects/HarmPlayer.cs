using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarmPlayer : MonoBehaviour
{
    public static readonly string HARMFUL_TAG = "Harmful";

    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float maxBounceForce = 15f;

    private PlayerStats playerStats;
    private Rigidbody rb;
    private bool canHarm;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        canHarm = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(PlayerStats.PLAYER_TAG) && canHarm)
        {
            canHarm = false;
            playerStats.Damage(damage);

            BounceOff();

            AudioManager.instance.Play("Clang");
            // TODO: player hurt animation
        }
    }

    private void BounceOff()
    {
        float xForce = Random.Range(-maxBounceForce, maxBounceForce);

        rb.AddForce(new Vector3(xForce, maxBounceForce, 0f), ForceMode.VelocityChange);
        rb.useGravity = true;

        Destroy(gameObject, 2f);
    }

}
