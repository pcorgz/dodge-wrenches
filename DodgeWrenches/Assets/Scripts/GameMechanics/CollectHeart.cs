using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHeart : MonoBehaviour
{
    public static readonly string HEART_TAG = "Heart";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerStats.PLAYER_TAG))
        {
            PlayerStats.Heal(1);
            // TODO: play heart collected sound/animation

            Destroy(gameObject);
        }
    }
}
