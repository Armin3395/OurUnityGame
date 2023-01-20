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

    public float Yrot1;
    bool rotLock = true;

    public GameObject soosiisObj;
    public Transform soosiis;

    Vector3 MarkLoc = new Vector3();

    //add Sleep

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetKey(KeyCode.Q))
        {
            if (canGrapple)
            {
                //this script currently grapples/moves to a point a bit below the crosshair
                //but it is not very important
                Vector3 forward2 = new(transform.forward.x, camTrans.forward.y, transform.forward.z);
                if (Physics.Raycast(transform.position, forward2, out hit, 400f, GrappleMask))
                {
                    if (rotLock)
                    {
                        MarkLoc = hit.point;
                        soosiisObj.SetActive(true);
                        soosiis.position = MarkLoc;
                        soosiis.eulerAngles = playerTrans.eulerAngles;
                        Yrot1 = transform.eulerAngles.y;
                        rotLock = false;
                    }
                    movescript.controller.Move(forward2 * Time.deltaTime * 60);

                    movescript.IsWall = true;
                    movescript.downVRes3();
                    if (transform.eulerAngles.y - Yrot1 > 15 || transform.eulerAngles.y - Yrot1 < -15)
                    {
                        canGrapple = false;
                    }
                }
                else
                {
                    movescript.IsWall = false;
                    soosiisObj.SetActive(false);
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
        if (Input.GetKeyUp(KeyCode.Q))
        {
            rotLock = true;
            canGrapple = true;
            soosiisObj.SetActive(false);
        }
    }
}


    


