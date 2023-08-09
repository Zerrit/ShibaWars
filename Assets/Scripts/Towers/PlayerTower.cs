using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTower : MainTower
{
    public BattleUI battleUI;

    public UnitsSpawner unitSpawner;
    public AbilitySystem abilitySystem;
    public ResourcesSystem resourcesSystem;

    public override void Start()
    {
        base.Start();

        battleUI.InitializeUnitButtons(unitSpawner);
        battleUI.InitializeAbilityButtons(abilitySystem);
        resourcesSystem.Init();
    }
}