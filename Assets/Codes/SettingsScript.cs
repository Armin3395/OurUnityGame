using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SettingsScript : MonoBehaviour
{
    public bool IsOpen = true;
    public PostProcessVolume volume;
    public PostProcessProfile nomot;
    public PostProcessProfile mot;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenCloseMenu();

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            MotionBlur();
        }
    }

    public void OpenCloseMenu()
    {
        if (IsOpen)
        {
            IsOpen = false;
        }
        else
        {
            IsOpen = true;
        }
    }
    public void MotionBlur()
    {
        if (volume.profile = nomot)
        {
        volume.profile = mot;
        }

    }
}
