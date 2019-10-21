using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmRemover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(HarmPlayer.HARMFUL_TAG))
        {
            var otherGameObject = other.gameObject;

            var harmerScripts = otherGameObject.gameObject.GetComponent<HarmPlayer>();
            Destroy(harmerScripts);

            var rb = otherGameObject.gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
            Destroy(otherGameObject.gameObject, 2f);

            other.gameObject.layer = 13;
        }

        if (other.CompareTag(CollectHeart.HEART_TAG))
        {
            Destroy(other.gameObject, 3f);
        }
    }
}
