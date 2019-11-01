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
    [SerializeField]
    private bool isVerticalMoving = false;

    private void Update()
    {
        float position = isVerticalMoving
                ? transform.position.y
                : transform.position.x;

        // If moving right and position >= maxPosX
        // or moving left and position <= minPosX
        if ((moveSpeed > 0 && position >= maxPosX)
                || (moveSpeed < 0 && position <= minPosX))
        {
            // Change direction
            moveSpeed *= -1;
        }
    }

    private void FixedUpdate()
    {
        float newPosX = moveSpeed * Time.deltaTime;
        float newPosY = Mathf.Sin(Time.time * frequency) * magnitude;

        if (isVerticalMoving)
        {
            transform.localPosition += new Vector3(newPosY, newPosX);
        }
        else
        {
            transform.localPosition += new Vector3(newPosX, newPosY);
        }
    }
}
