using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerSide
{
    leftPlayer,
    rightPlayer,
    neutral
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
    public bool IsDefeated { get; set; }

    public virtual void Start()
    {
        MaxHealth = maxHealth;
        CurrentHealth = MaxHealth;
        SelfTransform = transform;

        BattleCommunicator.instance.AddBuilding(this, playerSide);
    }

    public void GetDamage(float damage)
    {
        if (IsDefeated != true)
        {
            CurrentHealth -= damage;
            healthBar.localScale = new Vector2(Mathf.Clamp01(CurrentHealth / MaxHealth), 1f);

            if (CurrentHealth <= 0) DefeatSelf();
        }
    }

    public void DefeatSelf()
    {
        print(playerSide + "Был уничтожен");
    }
}
