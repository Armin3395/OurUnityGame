using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    //Hi
    public Movement moveScript;
    public Transform CamTrans;
    public Transform playrt;
    bool exmp;
    float def;
    Vector3 plyrtymi = new Vector3();

    private void FixedUpdate()
    {
        int LayerMaskInt = 1 << 8;

        RaycastHit hit;
        float a = playrt.position.y;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 3f, LayerMaskInt))
        {
            if (exmp == false)
            {
                moveScript.canjump1 = true;
                a = playrt.position.y;
                exmp = true;
            }
            if (playrt.position.y > a + 1)
            {
                def = playrt.position.y - a;
                for (int i = 0; i < def*10 ; i++)
                {
                    plyrtymi = new(playrt.position.x, playrt.position.y - 0.1f, playrt.position.z);
                    playrt.position = plyrtymi;
                }
            }
            if (!moveScript.isgrounded)
            {
                CamTrans.localEulerAngles = new(0, 0, 24 * (3.5f - hit.distance));
            }
            moveScript.IsWall = true;
        }
        if (Physics.Raycast(playrt.position, transform.TransformDirection(Vector3.left), out hit, 3f, LayerMaskInt))
        {
            Debug.Log(hit.distance);
            if (exmp == false)
            {
                moveScript.canjump1 = true;
                a = playrt.position.y;
                exmp = true;
            }
            if (playrt.position.y > a + 1)
            {
                def = playrt.position.y - a;
                for (int i = 0; i < def * 10; i++)
                {
                    plyrtymi = new(playrt.position.x, playrt.position.y - 0.1f, playrt.position.z);
                    playrt.position = plyrtymi;
                }
            }
            if (!moveScript.isgrounded)
            {
                CamTrans.localEulerAngles = new(0, 0, -24 * (3.5f - hit.distance));
            }
            moveScript.IsWall = true;
        }
        if (Physics.Raycast(playrt.position, transform.TransformDirection(Vector3.right), out hit, 3f, LayerMaskInt) == false && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 2f, LayerMaskInt) == false)
        {
            exmp = false;
            CamTrans.localEulerAngles = new(0, 0, 0);
            moveScript.IsWall = false;
        }

    }
}
