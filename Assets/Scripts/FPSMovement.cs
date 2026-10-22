using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = InputSystemManager.instance.inputs.Player.Move.ReadValue<Vector2>();
        dir.z = dir.y;
        dir.y = 0;

        dir = transform.TransformDirection(dir);

        // transform.position += transform.forward * dir.z * speed * Time.deltaTime;
        // transform.position += transform.right * dir.x * speed * Time.deltaTime;
        
        transform.position += dir * speed * Time.deltaTime;
    }
}
