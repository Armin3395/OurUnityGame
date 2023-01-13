using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject Player;
    public GameObject MiniCam;
    Vector3 camPos;
    //public Quaternion camrot;

    private void LateUpdate()
    {
        camPos.x = Player.transform.position.x;
        camPos.y = 25f + Player.transform.position.y;
        camPos.z = Player.transform.position.z;
        MiniCam.transform.position = camPos;

        //camrot.x = 90f;
       // camrot.y = Player.transform.rotation.y;
       // camrot.z = 0f;
        //MiniCam.transform.rotation = Quaternion.Euler(90f, Player.transform.rotation.y, 0f);
        MiniCam.transform.rotation = Quaternion.Euler(90f, Player.transform.eulerAngles.y, 0f);
    }
}
