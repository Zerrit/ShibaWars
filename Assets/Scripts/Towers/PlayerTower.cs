using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTower : MainTower
{
    public BattleUI battleUI;

    public ButtonParameters workerParameters;
    public UnitsSpawner unitSpawner;
    public AbilityCaster abilityCaster;
    public ResourcesSystem resourcesSystem;

    public override void Start()
    {
        base.Start();

        battleUI.InitializeWorkerButton(workerParameters);
        battleUI.InitializeUnitButtons(unitSpawner);
        battleUI.InitializeAbilityButtons(abilityCaster);
        resourcesSystem.Init();
    }
}