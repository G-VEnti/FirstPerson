using System;
using UnityEngine;

public class VRotation : MonoBehaviour
{
    public float vRotSpeed;
    public float vRotY = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vRotY += -InputSystemManager.instance.mouseDelta.y * vRotSpeed;

        vRotY = Mathf.Clamp(vRotY, -45, 45);

        transform.localRotation = Quaternion.Euler(vRotY, 0, 0);

        Debug.Log(transform.localEulerAngles.x);
    }
}
