using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 8f;

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        transform.position += new Vector3(horizontal, 0f);
    }
}
