using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMover : MonoBehaviour
{
    [SerializeField]
    private float minPosX = 0f;
    [SerializeField]
    private float maxPosX = 0f;
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float frequency = 20f;
    [SerializeField]
    private float magnitude = 0.5f;

    private void Update()
    {
        // If moving right and position >= maxPosX
        // or moving left and position <= minPosX
        if ((moveSpeed > 0 && transform.position.x >= maxPosX)
                || (moveSpeed < 0 && transform.position.x <= minPosX))
        {
            // Change direction
            moveSpeed *= -1;
        }
    }

    private void FixedUpdate()
    {
        float newPosX = moveSpeed * Time.deltaTime;
        float newPosY = Mathf.Sin(Time.time * frequency) * magnitude;

        transform.position += new Vector3(newPosX, newPosY);
    }
}
