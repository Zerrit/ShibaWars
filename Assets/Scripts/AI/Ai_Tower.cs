using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Tower : MainTower
{
    public MiniMap miniMap;

    [Header("Economics")]
    public int towerGold;
    public int towerMana;

    public Transform unitPoolTransform;

    [Header("Units")]
    public ShibaSlave slave;
    public Entity samurai;
    public Entity archer;
    public Entity ninja;
    public Entity oni;

    private ObjectPooller<Entity> samuraiPool;
    private ObjectPooller<Entity> archerPool;
    private ObjectPooller<Entity> technicPool;
    private ObjectPooller<Entity> elitPool;

    [Header("OtherParameters")]
    public GameObject spawnVFX;
    private int passiveIncomingTime = 0;


    public override void Start()
    {
        base.Start();

        samuraiPool = new EntityPooler(samurai, unitPoolTransform, 1, true);
        //archerPool = new ObjectPooller<Entity>(archer, 4, unitPoolTransform);
        //technicPool = new ObjectPooller<Entity>(ninja, 2, unitPoolTransform);
        //elitPool = new ObjectPooller<Entity>(oni, 2, unitPoolTransform);
}


    public void Update()
    {
        PassiveIncoming();
    }
    

    public void CreateShibaSlave()
    {
    }

    public void CreateShibaSamurai()
    {
        Entity unit = samuraiPool.GetFreeElement();
        Instantiate(spawnVFX, unit.SelfTransform);
        BattleCommunicator.instance.AddUnit(unit);

        //miniMap.AddNewIcon(unit);
    }

    public void CreateShibaArcher()
    {
        Entity unit = archerPool.GetFreeElement();
        BattleCommunicator.instance.rightPlayerUnits.Add(unit);
    }

    public void CreateShibaNinja()
    {
        Entity unit = technicPool.GetFreeElement();
        BattleCommunicator.instance.rightPlayerUnits.Add(unit);
    }

    public void CreateShibaOni()
    {
        Entity unit = elitPool.GetFreeElement();
        BattleCommunicator.instance.rightPlayerUnits.Add(unit);
    }

    private void PassiveIncoming()
    {
        if (Time.time > passiveIncomingTime)
        {
            passiveIncomingTime += 3;
            //gold++;
            //mana++;
        }
    }
}
