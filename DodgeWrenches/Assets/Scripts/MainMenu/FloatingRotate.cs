using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingRotate : MonoBehaviour
{
    private float randomX;
    private float randomY;
    private float randomZ;

    private void Start()
    {
        randomX = Random.Range(-50, 50);
        randomY = Random.Range(-50, 50);
        randomZ = Random.Range(-50, 50);
    }

    private void Update()
    {
        var newRotation = new Vector3(randomX, randomY, randomZ) * Time.deltaTime;
        transform.Rotate(newRotation);
    }
}
