using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class povorotcamera : MonoBehaviour
{
    public Transform pl;
    float xRot = 0f;
    
    public float rotationSpeed = 150f;

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed *Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed *Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        pl.Rotate(Vector3.up * mouseX);
    }
}
