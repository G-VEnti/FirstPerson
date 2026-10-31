using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float rayLength;
    public float rayOriginOffset;
    private Rigidbody rb;
    private Vector3 dir;
    private Vector3 rayOriginPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rayOriginPos = new Vector3(0, rayOriginOffset, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast hit control
        if (Physics.Raycast(transform.position + rayOriginPos, -transform.up, rayLength))
        {
            Debug.DrawRay(transform.position + rayOriginPos, -transform.up * rayLength, Color.green);

            dir = InputSystemManager.instance.inputs.Player.Move.ReadValue<Vector2>();
            dir.z = dir.y;
            dir.y = 0;

            dir = transform.TransformDirection(dir);


            if (InputSystemManager.instance.inputs.Player.Jump.WasPressedThisFrame())
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
        else
        {
            Debug.DrawRay(transform.position + new Vector3(0, rayOriginOffset, 0), -transform.up * rayLength, Color.red);
        }

        transform.position += dir * speed * Time.deltaTime;
    }
}
