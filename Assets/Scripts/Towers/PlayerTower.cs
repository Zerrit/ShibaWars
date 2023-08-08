using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTower : MainTower
{
    public BattleUI battleUI;

    [Header("OtherParameters")]
    //private int passiveIncomingTime = 0;

    public UnitsSpawner unitSpawner;
    public AbilitySystem abilitySystem;

    public override void Start()
    {
        base.Start();

        battleUI.InitializeUnitButtons(unitSpawner);
        battleUI.InitializeAbilityButtons(abilitySystem);
    }

    public void Update()
    {
        //PassiveIncoming();
    }



}
