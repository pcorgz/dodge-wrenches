using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHeart : MonoBehaviour
{
    public static readonly string HEART_TAG = "Heart";

    [SerializeField]
    private MeshRenderer bodyMesh = null;
    [SerializeField]
    private GameObject particles = null;

    private PlayerStats playerStats = null;

    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerStats.PLAYER_TAG))
        {
            playerStats.Heal(1);
            AudioManager.instance.Play("CollectHeart");

            var particlesGameObject = Instantiate(particles, transform.position, Quaternion.Euler(-90, 0f, 0f));

            GetComponent<Collider>().enabled = false;
            bodyMesh.enabled = false;

            Destroy(gameObject, 1.2f);
            Destroy(particlesGameObject, 1f);
        }
    }
}
