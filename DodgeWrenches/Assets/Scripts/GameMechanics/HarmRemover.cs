using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmRemover : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(HarmPlayer.HARMFUL_TAG))
        {
            var root = other.gameObject.transform.parent.gameObject;

            var harmerScripts = root.gameObject.GetComponent<HarmPlayer>();
            Destroy(harmerScripts);

            var rb = root.gameObject.GetComponent<Rigidbody>();
            rb.useGravity = true;
            Destroy(root.gameObject, 2f);

            other.gameObject.layer = 13;
        }
    }
}
