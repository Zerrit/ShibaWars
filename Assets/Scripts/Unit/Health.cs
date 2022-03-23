using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Transform healthBar;

    public Collider2D col { get; private set; }
    

    private void Start()
    {
        col = gameObject.GetComponent<Collider2D>();

        currentHealth = maxHealth;
    }

    public void GetDamage(float damage)
    {
        if (col.enabled == true)
        {
            currentHealth -= damage;
            healthBar.localScale = new Vector2(Mathf.Clamp01(currentHealth/maxHealth), 1f);
        }

        if (currentHealth <= 0)
        {
            ActiveDeath();
        }
    }


    public void ActiveDeath()
    {
        col.enabled = false;
        Destroy(gameObject, 1.5f);
    }
}
