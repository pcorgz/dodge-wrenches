using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLight : MonoBehaviour
{
    [SerializeField]
    private Transform rotationCenter = null;
    [SerializeField]
    private float rotationRadius = 2f;
    [SerializeField]
    private float angularSpeed = 2f;

    private float posX;
    private float posY;
    private float angle;

    private void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.x + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector3(posX, posY);
        angle += Time.deltaTime * angularSpeed;

        if (angle > 360) angle = 0f;
    }
}
