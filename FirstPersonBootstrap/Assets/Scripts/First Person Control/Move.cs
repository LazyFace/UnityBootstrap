using UnityEngine;

[RequireComponent(typeof(Collider),typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    public float walkSpeed = 5;
    public float runSpeed = 10;
    public KeyCode runKey = KeyCode.LeftShift;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float speed = Input.GetKey(runKey) ? runSpeed : walkSpeed;

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 movementInput = new Vector3(inputX, 0, inputZ).normalized * speed;

        Vector3 movementDirection = transform.TransformDirection(movementInput);

        rb.velocity = new Vector3(movementDirection.x, rb.velocity.y, movementDirection.z);

        //rb.AddForce(movementDirection, ForceMode.Acceleration);
    }
}
