using UnityEngine;

public class HRotation : MonoBehaviour
{
    public float hRotSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles += new Vector3(0, InputSystemManager.instance.mouseDelta.x * hRotSpeed, 0);
    }
}
