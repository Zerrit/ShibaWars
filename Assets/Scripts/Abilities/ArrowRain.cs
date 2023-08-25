using System.Collections.Generic;
using UnityEngine;


public class ArrowRain : Ability
{
    [Header("Дополнительные параметры")]
    public int damage;
    public int lifeTime = 6;

    private float spawnTime;
    private float lastDamageTime = 0;
    private Vector2 abilityPlace;
    List<IDamageable> allTargets;


    private void OnEnable()
    {
        lastDamageTime = Time.time;
        spawnTime = Time.time;
    }
    private void Update()
    {
        DamageAllTargers();
        if (Time.time > spawnTime + lifeTime) FinishAbility();
    }


    public override void Initialize(Side side)
    {
        this.side = side;
        allTargets = new List<IDamageable>();
    }


    public override bool SelectTarget(Vector2 touchPoint)
    {
        abilityPlace = BattleCommunicator.instance.GetPositionByX(touchPoint);
        return true;
    }

    public override void UseAbility()
    {
        transform.position = abilityPlace;
    }
    private void DamageAllTargers()
    {
        if (Time.time >= lastDamageTime + 0.25f)
        {
            allTargets = BattleCommunicator.instance.CheckUnitsAround((Vector2)transform.position);

            foreach (IDamageable target in allTargets)
            {
                target.GetDamage(5);
                lastDamageTime = Time.time;
            }
        }
    }
    private void FinishAbility()
    {
        allTargets.Clear();
        gameObject.SetActive(false);
    }
}