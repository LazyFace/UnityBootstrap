using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public float jumpStrength = 5;
    public KeyCode jumpKey = KeyCode.Space;

    public float groundCheckDistance = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(jumpKey) && IsGrounded())
        {
            rb.AddForce(rb.transform.up * jumpStrength, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);

        Gizmos.DrawSphere(transform.position + Vector3.down * groundCheckDistance, 0.05f);
    }
}
