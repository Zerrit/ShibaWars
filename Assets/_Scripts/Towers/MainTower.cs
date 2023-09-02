using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side
{
    left,
    right,
    neutral
}

public class MainTower : MonoBehaviour, IDamageable
{
    public Side playerSide;

    public int maxHealth = 250;
    public float distance;
    [SerializeField] private HealthBar _healthBar;

    public Transform SelfTransform { get; set; }
    public bool IsDefeated { get; set; }

    public virtual void Initialize()
    {
        _healthBar.Initialize(maxHealth, playerSide);
        SelfTransform = transform;

        BattleCommunicator.instance.AddBuilding(this, playerSide);
    }

    public void GetDamage(int damage)
    {
        if (IsDefeated == false)
        {
            _healthBar.ReduceHealth(damage);

            if (!_healthBar.HasHealth()) DefeatSelf();
        }
    }

    public void DefeatSelf()
    {
        print(playerSide + "Был уничтожен");
    }
}
