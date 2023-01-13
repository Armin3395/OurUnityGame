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

        if (Input.GetKey(KeyCode.Q))
        {
            if (Physics.Raycast(camTrans.position, transform.TransformDirection(Vector3.forward), out hit, 60f))
            {
                float step = speed * Time.deltaTime;
                Debug.Log(hit.point);
                //move player to hit.point
                //playerTrans.Translate(Vector3.forward * Time.deltaTime);
                movedir = camTrans.TransformDirection(Vector3.forward) * 5;
                movescript.controller.Move(movedir * 10 *Time.deltaTime);
            }
        }
    }
}


    


