using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StartFalling : MonoBehaviour
{
    [SerializeField]
    private float fallingVelocity = 10f;
    [SerializeField]
    private float horizontalVelocity = 0f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = new Vector3(horizontalVelocity, -fallingVelocity);
    }
}
