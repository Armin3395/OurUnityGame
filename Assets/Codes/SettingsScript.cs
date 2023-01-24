using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public bool IsOpen = false;
    public PostProcessVolume volume;
    public PostProcessProfile nomot;
    public PostProcessProfile mot;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    public Button button6;
    public Button button7;

    public Movement moveScript;
    public WallRunning WallScript;
    public CamMovement CamScript;
    public grapple GrappleScript;
    public SwordScript SwordScr;

    /*void OnGUI()
    {
        string[] names = QualitySettings.names;
        GUILayout.BeginVertical();
        for (int i = 0; i < names.Length; i++)
        {
            if (GUILayout.Button(names[i]))
            {
                QualitySettings.SetQualityLevel(i, true);
            }
        }
        GUILayout.EndVertical();
    }*/

    public void SetQualityVoid(int i)
    {
        QualitySettings.SetQualityLevel(i, true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenCloseMenu();
        }
    }
    public void OpenCloseMenu()
    {
        if (IsOpen)
        {
            IsOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            button3.gameObject.SetActive(false);
            button4.gameObject.SetActive(false);
            button5.gameObject.SetActive(false);
            button6.gameObject.SetActive(false);
            button7.gameObject.SetActive(false);
            moveScript.enabled = true;
            WallScript.enabled = true;
            GrappleScript.enabled = true;
            CamScript.enabled = true;
            SwordScr.enabled = true;
        }
        else
        {
            IsOpen = true;
            Cursor.lockState = CursorLockMode.None;
            button1.gameObject.SetActive(true);
            button2.gameObject.SetActive(true);
            button3.gameObject.SetActive(true);
            button4.gameObject.SetActive(true);
            button5.gameObject.SetActive(true);
            button6.gameObject.SetActive(true);
            button7.gameObject.SetActive(true);
            moveScript.enabled = false;
            WallScript.enabled = false;
            GrappleScript.enabled = false;
            CamScript.enabled = false;
            SwordScr.enabled = false;
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
