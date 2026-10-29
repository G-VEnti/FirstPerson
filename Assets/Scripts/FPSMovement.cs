using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float rayLength;
    public float rayOriginOffset;
    private Rigidbody rb;
    Vector3 dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;


        // Raycast hit control
        if (Physics.Raycast(transform.position + new Vector3(0, rayOriginOffset, 0), -transform.up, out hit, rayLength))
        {
            Debug.DrawRay(transform.position + new Vector3(0, rayOriginOffset, 0), -transform.up * rayLength, Color.green);

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


        //if (hit == null)


        // transform.position += transform.forward * dir.z * speed * Time.deltaTime;
        // transform.position += transform.right * dir.x * speed * Time.deltaTime;


    }
}
