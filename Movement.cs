using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 16f;
    Vector3 velocity;
    public float gravity = -19.62f;
    public bool IsWall;
    //public int jumpTimes = 2;

    public Transform groundCheck;
    public float groundDistance = 0.8f;
    public LayerMask groundMask;
    bool isgrounded;
    public float downV = 6f;
    public float jumpHeight = 3f;
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -downV;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //if (isgrounded == true)
             speed = 22f; 
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 16f;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * y;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && (isgrounded || !IsWall))
        {
            
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (IsWall)
        {
            GvAdd();
        }
        if (!IsWall)
        {
            downVRes2();
        }
        

        
        controller.Move(velocity * Time.deltaTime);
    }
    public void downVRes()
    {
        velocity.y = downV;
    }
    public void downVRes2()
    {
        velocity.y += gravity/2 *Time.deltaTime;
    }
    public void GvAdd()
    {
        velocity.y += gravity * Time.deltaTime;
    }
}
