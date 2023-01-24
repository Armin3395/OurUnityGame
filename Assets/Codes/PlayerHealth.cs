using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public Image HealthBar;
    public Movement moveScript;
    public WallRunning WallScript;
    public CamMovement CamScript;
    public grapple GrappleScript;
    public SwordScript SwordScr;
    public Image RedDie;
    public Button Respawn;

    private void Update()
    {
        if (health <= 0)
        {
            moveScript.enabled = false;
            WallScript.enabled = false;
            GrappleScript.enabled = false;
            CamScript.enabled = false;
            SwordScr.enabled = false;
            RedDie.gameObject.SetActive(true);
            Respawn.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

            //RedDie.enabled = true;
            Respawn.enabled = true;
        }
        if (health < 0)
        {
            health = 0;
        }
        HealthBar.rectTransform.localScale = new(health/100, HealthBar.rectTransform.localScale.y, HealthBar.rectTransform.localScale.z);
    }
    public void OnParticleCollision(GameObject PlayerObj)
    {
        if (PlayerObj.layer == 10)
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    public void RespawnVoid()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
