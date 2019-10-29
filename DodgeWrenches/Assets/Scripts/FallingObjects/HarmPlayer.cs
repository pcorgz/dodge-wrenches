using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarmPlayer : MonoBehaviour
{
    public static readonly string HARMFUL_TAG = "Harmful";
    public static readonly string HARM_REMOVER_TAG = "HarmRemover";

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

    private void OnEnable()
    {
        gameObject.layer = 9;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(HARM_REMOVER_TAG))
        {
            canHarm = false;
            
            rb.useGravity = true;

            StartCoroutine(GameManager.DisableGameObject(gameObject));
            gameObject.layer = 13;
        }
    }

    private void BounceOff()
    {
        float xForce = Random.Range(-maxBounceForce, maxBounceForce);

        rb.AddForce(new Vector3(xForce, maxBounceForce, 0f), ForceMode.VelocityChange);
        rb.useGravity = true;

        //Destroy(gameObject, 2f);
        StartCoroutine(GameManager.DisableGameObject(gameObject));
    }

}
