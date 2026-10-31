using TreeEditor;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    public float rayLength = 2f;
    public float grabbedDistance = 2f;
    public float maxGrabbedDistance = 50f;
    public float minGrabbedDistance = 2f;
    public float grabbedSpeed = 1f;
    private bool grabbed = false;
    private GameObject hitObject;
    private RaycastHit hit;
    private Vector3 grabbedPos;
    private Vector3 grabbedMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Raycast hit check
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            Debug.DrawRay(hit.point, transform.forward * (rayLength - hit.distance), Color.green);

            // Check if the object have Rigidbody
            if (hit.collider.gameObject.GetComponent<Rigidbody>() != null)
            {
                // Save gameObject if no other one grabbed
                if (grabbed == false) hitObject = hit.collider.gameObject;                    
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);
            if (grabbed == false) hitObject = null;
        }

        if (hitObject != null)
        {
            // Check player input
            if (InputSystemManager.instance.inputs.Player.Interact.IsPressed())
            {
                grabbed = true;

                // Disable grabbed object's gravity
                hitObject.GetComponent<Rigidbody>().useGravity = false;

                // Change grabbed object distance with mouse scroll
                if (InputSystemManager.instance.inputs.Player.Scroll.ReadValue<Vector2>().y > 0) grabbedDistance += 1;
                else if (InputSystemManager.instance.inputs.Player.Scroll.ReadValue<Vector2>().y < 0) grabbedDistance -= 1;

                grabbedDistance = Mathf.Clamp(grabbedDistance, minGrabbedDistance, maxGrabbedDistance);

                // Grabbed object movement
                grabbedPos = hitObject.transform.position;
                grabbedMovement = (transform.position + transform.forward * grabbedDistance) - grabbedPos;
                hitObject.GetComponent<Rigidbody>().linearVelocity = grabbedMovement * grabbedSpeed;
            }
            else
            {
                // Reset
                grabbed = false;
                hitObject.GetComponent<Rigidbody>().useGravity = true;
                grabbedDistance = 2f;
            }
        }
        Debug.Log(hitObject);
    }
}
