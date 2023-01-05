using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    public Movement moveScript;
    public Transform CamTrans;
    //public Camera cam;
    Quaternion targetm = Quaternion.Euler(0, 0, -18);
    Quaternion targetp = Quaternion.Euler(0, 0, 18);
    public Transform wallt;
    public Transform playrt;

    private void FixedUpdate()
    {
        int LayerMaskInt = 1 << 8;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 2f, LayerMaskInt))
        {

            //CamTrans.localRotation = Quaternion.RotateTowards(transform.localRotation, targetm, Time.deltaTime * 50);
            CamTrans.localEulerAngles = new(0, 0, 24 * (2f - hit.distance));
            //moveScript.downVRes2();
            moveScript.IsWall = false;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 2f, LayerMaskInt))
        {
            //CamTrans.localRotation = Quaternion.RotateTowards(transform.localRotation, targetm, Time.deltaTime * 50);
            CamTrans.localEulerAngles = new(0, 0, -24 * (2f - hit.distance));
            //moveScript.downVRes2();
            moveScript.IsWall = false;

        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 2f, LayerMaskInt) == false && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 2f, LayerMaskInt) == false)
        {
            CamTrans.localEulerAngles = new(0, 0, 0);
            moveScript.IsWall = true;
        }
    }
}
