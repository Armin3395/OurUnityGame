using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 15f;
    Vector3 velocity;
    public float gravity = -20f;
    public bool IsWall;
    public Transform groundCheck;
    public float groundDistance = 0.8f;
    public LayerMask groundMask;
    public bool isgrounded;
    public float downV = 6f;
    public float jumpHeight = 5f;

    public Transform playertrans;
    public WallRunning wallScript;
    public bool canjump1 = false;

    private float fps = 30f;

    void OnGUI()
    {
        //this void calculates and shows fps
        float newFPS = 1.0f / Time.smoothDeltaTime;
        fps = Mathf.Lerp(fps, newFPS, 0.005f);
        GUI.Label(new Rect(0, 0, 100, 100), "FPS: " + ((int)fps).ToString());

    }
    private void Start()
    {
        Application.targetFrameRate = 120;
    }
    void Update()
    {
        //this method of detecting isgrounded allows player to do jump over everything layered Ground
        //isgrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Physics.Raycast(playertrans.position, Vector3.down, 2f, groundMask))
        {
            isgrounded = true;
        }
        else
        {
            isgrounded = false;
        }
        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -downV;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 23f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 15f;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && (isgrounded || canjump1))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            if (canjump1 == true)
            {
                canjump1 = false;
            }
        }
        if (IsWall)
        {
            downVRes2();
        }
        if (!IsWall)
        {
            GvAdd();
        }



        controller.Move(velocity * Time.deltaTime);
    }
    public void downVRes2()
    {
        velocity.y += gravity / 3 * Time.deltaTime;
    }
    public void GvAdd()
    {
        velocity.y += gravity * Time.deltaTime;
    }
    public void downVRes3()
    {
        if (velocity.y <0)
        {
            // should become smoother for example using Lerp
            velocity.y = velocity.y / 2;
        }
    }
}
