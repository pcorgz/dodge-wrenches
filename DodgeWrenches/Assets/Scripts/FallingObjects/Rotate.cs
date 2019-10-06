using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 50f;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime));
    }
}
