using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarmRemover : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var harmer = other.gameObject.GetComponent<HarmPlayer>();
        Destroy(harmer);
    }
}
