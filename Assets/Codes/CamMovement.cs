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
    public float newFPS;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //public float fps = 30f;

    void OnGUI()
    {
        //this void calculates and shows fps
        newFPS = 1.0f / Time.smoothDeltaTime;
        //fps = Mathf.Lerp(fps, newFPS, 0.0005f);
    }
        void Update()
    {
        //Debug.Log(newFPS);
        if (newFPS < 50)
        {
            MouseSensX = 140 + newFPS;
        }
        if (newFPS < 70 && newFPS > 50)
        {
            MouseSensX = newFPS + 100;
        }
        if(newFPS > 70 && newFPS < 100)
        {
            MouseSensX = newFPS + 190;
        }
        if (newFPS > 100)
        {
            MouseSensX = newFPS + 230;
        }

        float MouseX = Input.GetAxis("Mouse X") * MouseSensX * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensY * Time.deltaTime;

        xrotation -= MouseY;
        xrotation = Mathf.Clamp(xrotation, -maxangle, maxangle);

        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        playerbody.Rotate(Vector3.up * MouseX);



    }
}
