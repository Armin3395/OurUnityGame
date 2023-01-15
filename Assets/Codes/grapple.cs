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
    bool canGrapple = true;
    public IEnumerator coroutine;
    public LayerMask GrappleMask;

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetKey(KeyCode.Q))
        {
            if (canGrapple )
            {
                Vector3 forward2 = new(transform.forward.x, camTrans.forward.y, transform.forward.z);
                if (Physics.Raycast(transform.position, forward2, out hit, 200f, GrappleMask))
                {
                    movescript.controller.Move(forward2 * Time.deltaTime * 130);

                    movescript.IsWall = true;
                    movescript.downVRes3();
                    coroutine = WaitF(3f, 1);
                    StartCoroutine(coroutine);
                    if (Input.GetKeyUp(KeyCode.Q))
                    {
                        //StopAllCoroutines();
                        canGrapple = false;
                        coroutine = WaitF(0.5f, 2);
                        StartCoroutine(coroutine);
                    }
                }
                else
                {
                    movescript.IsWall = false;
                }
            }
            else
            {
                movescript.IsWall = false;
            }
        }
        else
        {
            movescript.IsWall = false;
        }
    }
    IEnumerator WaitF(float waitTime, int which)
    {
        yield return new WaitForSeconds(waitTime);
        {
            if (which == 1)
            {
                canGrapple = false;
                coroutine = WaitF(0.5f, 2);
                StartCoroutine(coroutine);
            }
            if (which == 2)
            {
                canGrapple = true;
            }
            if (which == 3)
            {
                canGrapple = false;
            }
        }
    }
}


    


