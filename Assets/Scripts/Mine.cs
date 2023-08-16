using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mine : MonoBehaviour, IDamageable
{

    public int maxHealth = 250;
    public float distance;
    public Transform healthBar;



    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Transform SelfTransform { get; set; }
    public bool IsDead { get; set; }

    public PlayerSide playerSide;

    private void Start()
    {
        MaxHealth = maxHealth;
        SelfTransform = transform;

        if (!IsDead)
        {
            CurrentHealth = MaxHealth;
            EventsManager.instance.TakeMine();
        }
    }






    public void GetDamage(float damage)
    {
        if (IsDead != true)
        {
            Mathf.Clamp(CurrentHealth -= damage, 0, MaxHealth);
            healthBar.localScale = new Vector2(Mathf.Clamp01(CurrentHealth / MaxHealth), 1f);

            if (CurrentHealth <= 0) KillSelf();
        }
    }

    public void KillSelf()
    {
        IsDead = true;
        EventsManager.instance.LostMine();
    }
}
