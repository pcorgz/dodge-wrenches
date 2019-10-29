using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallingObject : PooledMonoBehaviour
{
    [SerializeField]
    private float minFallingVelocity = 0f;
    [SerializeField]
    private float maxFallingVelocity = 0f;
    [SerializeField]
    private float minHorizontalVelocity = 0f;
    [SerializeField]
    private float maxHorizontalVelocity = 0f;

    private Rigidbody rb;
    private float fallingVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        fallingVelocity = Random.Range(minFallingVelocity, maxFallingVelocity);
        var horizontalVelocity = Random.Range(minHorizontalVelocity, maxHorizontalVelocity);

        rb.velocity = new Vector3(horizontalVelocity, fallingVelocity);
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.y < fallingVelocity
                ? new Vector3(rb.velocity.x, fallingVelocity)
                : rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            int rand = Random.Range(1, 4);

            AudioManager.instance.Play($"Hit_{rand}");
        }
    }
}
