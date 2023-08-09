using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerSide
{
    leftPlayer,
    rightPlayer
}

public class MainTower : MonoBehaviour, IDamageable
{
    public PlayerSide playerSide;

    public int maxHealth = 250;
    public float distance;
    public Transform healthBar;

    public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Transform SelfTransform { get; set; }
    public bool IsDead { get; set; }

    public virtual void Start()
    {
        MaxHealth = maxHealth;
        CurrentHealth = MaxHealth;
        SelfTransform = transform;

        BattleCommunicator.instance.AddMainTower(this);
    }

    public void GetDamage(float damage)
    {
        if (IsDead != true)
        {
            CurrentHealth -= damage;
            healthBar.localScale = new Vector2(Mathf.Clamp01(CurrentHealth / MaxHealth), 1f);

            if (CurrentHealth <= 0) KillSelf();
        }
    }

    public void KillSelf()
    {
        print(playerSide + "Был уничтожен");
    }
}
