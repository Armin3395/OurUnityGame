using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SocialPlatforms;

public class SwordScript : MonoBehaviour
{
    public Animator anim;
    public IEnumerator coroutine;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("AttackTrig");
            coroutine = Check(0.45f, 1);
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
                anim.SetTrigger("DontEx1");
                coroutine = Check(0.4f, 2);
                StartCoroutine(coroutine);
            }
            if (which == 2 && !Input.GetKey(KeyCode.Mouse0))
            {
                anim.SetTrigger("ExitFrom2");
            }
            if (which == 2 && Input.GetKey(KeyCode.Mouse0))
            {
                anim.SetTrigger("DontEx2");
            }
        }
    }
}

