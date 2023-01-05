using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapple : MonoBehaviour
{
    public LayerMask lyrs;
    public LineRenderer lr;

    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, cameraa, player;
    private float maxDistance = 100f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartHit();
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopHit();
        }
    }

    public void StartHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, lyrs))
        {
            grapplePoint = hit.point;

        }
    }
    public void StopHit()
    {

    }

    private void FixedUpdate()
    {



        // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        //Debug.Log("Did Hit");

    }
    //else
    //{
    // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
    //Debug.Log("Did not Hit");
    }


