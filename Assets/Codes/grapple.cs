using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class grapple : MonoBehaviour
{
    public Transform camTrans;
    public Transform playerTrans;
    public float speed = 10.0f;
    public Vector3 currentpos;
    public Movement movescript;
    Vector3 movedir;
    private void Update()
    {
        RaycastHit hit;
        //Debug.Log(camTrans.forward);
        if (Input.GetKey(KeyCode.Q))
        {
            //if (Physics.Raycast(camTrans.position, transform.TransformDirection(Vector3.forward), out hit, 60f))
            //{
           // Vector3 dirv = new(camTrans.localRotation.x, playerTrans.rotation.y, playerTrans.rotation.z);

                Ray frontRay = new Ray(transform.position, transform.forward);
            Vector3 forwardvec = new(camTrans.forward.x, transform.forward.y, transform.forward.z);
            if (Physics.Raycast(transform.position, forwardvec, out hit, 100f))
            {
                //Debug.Log(forwardvec);
                //Debug.Log(hit.point);
                //Debug.Log(camTrans.forward.x);
            }
                float step = speed * Time.deltaTime;
            //Debug.Log(transform.rotation);
            //move player to hit.point
            //playerTrans.Translate(Vector3.forward * Time.deltaTime);
            //movedir = camTrans.TransformDirection(Vector3.forward) * 5;
            //Vector3 forward1 = new(camTrans.forward.x, transform.forward.y, transform.forward.z);
            Vector3 forward2 = new(transform.forward.x, camTrans.forward.y, transform.forward.z);
            if (Physics.Raycast(transform.position, forward2, out hit, 100f))
            {
               movescript.controller.Move(forward2 *Time.deltaTime * 130);
                //Debug.DrawRay(transform.position, forward2);
               // Debug.Log("Joe");
            }
           // }
        }
    }
}


    


