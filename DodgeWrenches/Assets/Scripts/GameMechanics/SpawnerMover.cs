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
    private float moveSpeed = 0f;

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
        transform.position += new Vector3(newPosX, 0f);
    }
}
