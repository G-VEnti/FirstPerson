using System;
using UnityEngine;

public class VRotation : MonoBehaviour
{
    public float vRotSpeed = 0.0f;
    public float vRotY = 0.0f;
    public float rotAngle = 45f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vRotY += -InputSystemManager.instance.mouseDelta.y * vRotSpeed;

        vRotY = Mathf.Clamp(vRotY, -rotAngle, rotAngle);

        transform.localRotation = Quaternion.Euler(vRotY, 0, 0);
    }
}
