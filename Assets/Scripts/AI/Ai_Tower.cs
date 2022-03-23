using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Tower : MainTower
{
    public MiniMap miniMap;

    [Header("Economics")]
    public int towerGold;
    public int towerMana;


    [Header("Units")]
    public ShibaSlave slave;
    public Entity samurai;
    public Entity archer;
    public Entity ninja;
    public Entity oni;

    public List<Entity> slaves = new List<Entity>();


    [Header("OtherParameters")]

    public Vector2 spawnPoint;
    private int passiveIncomingTime = 0;


    public void Update()
    {
        PassiveIncoming();
    }
    

    public void CreateShibaSlave()
    {
        ShibaSlave shiba = Instantiate(slave, spawnPosition, transform.rotation);
        shiba.CastlePos = transform.position;
        shiba.mainTowerGold = this;
        slaves.Add(shiba);
    }

    public void CreateShibaSamurai()
    {
        Entity unit = Instantiate(samurai, spawnPosition, transform.rotation);
        miniMap.AddNewIcon(unit);
    }

    public void CreateShibaArcher()
    {
        Instantiate(archer, spawnPosition, transform.rotation);
    }

    public void CreateShibaNinja()
    {
        Instantiate(ninja, spawnPosition, transform.rotation);
    }

    public void CreateShibaOni()
    {
        Instantiate(oni, spawnPosition, transform.rotation);
    }

    private void PassiveIncoming()
    {
        if (Time.time > passiveIncomingTime)
        {
            passiveIncomingTime += 1;
            gold++;
            mana++;
        }
    }
}
