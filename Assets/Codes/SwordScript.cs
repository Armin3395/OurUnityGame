using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Animator anim;
    public IEnumerator coroutine;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("AttackTrig");
            coroutine = Check(1f, 1);
            StartCoroutine(coroutine);
        }


    }
    IEnumerator Check(float waitTime, int which)
    {
        yield return new WaitForSeconds(waitTime);
        {
            if (which == 1 && !Input.GetKey(KeyCode.Mouse0))
            {
                anim.SetTrigger("ExitFrom1");
            }
            if (which == 1 && Input.GetKey(KeyCode.Mouse0))
            {
                coroutine = Check(1f, 2);
                StartCoroutine(coroutine);
            }
            if (which == 2 && !Input.GetKey(KeyCode.Mouse0))
            {
                anim.SetTrigger("ExitFrom2");
            }
        }
    }
}

