using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public Image HealthBar;
    private void Update()
    {
        if (health <= 0)
        {
            //die
            Debug.Log("He Died Of Ligma Cancer");
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
}
