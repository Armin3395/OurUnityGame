using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    float xrotation = 0f;
    public float MouseSensX = 100f;
    public float MouseSensY = 100f;
    public Transform playerbody;
    public float maxangle = 80f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * MouseSensX * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensY * Time.deltaTime;

        xrotation -= MouseY;
        xrotation = Mathf.Clamp(xrotation, -maxangle, maxangle);

        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * MouseX);



    }
}
