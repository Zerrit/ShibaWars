using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHandler : MonoBehaviour
{
    private UnitsSpawner unitSpawner;
    private AbilitySystem abilitySystem;

    private void Start()
    {
        unitSpawner = GetComponent<UnitsSpawner>();
        abilitySystem = GetComponent<AbilitySystem>();
    }

    private void OnEnable()
    {
        UIEvents.OnUnitUpgrade += UpgradeUnit;
        UIEvents.OnAbilityUpgrade += UpgradeAbility;
    }
    private void OnDisable()
    {
        UIEvents.OnUnitUpgrade -= UpgradeUnit;
        UIEvents.OnAbilityUpgrade -= UpgradeAbility;
    }

    public void UpgradeUnit(int playerSide, int unitId, int upgradeOption)
    {
        if ((int)unitSpawner.tower.playerSide != playerSide) return;

        if (unitSpawner.unitsStruct[unitId].upgradePath == 0) unitSpawner.unitsStruct[unitId].upgradePath = upgradeOption;
        else unitSpawner.unitsStruct[unitId].subUpgradePath = upgradeOption;
    }

    public void UpgradeAbility(int playerSide, int abilityId, int upgradeOption)
    {
        if ((int)abilitySystem.tower.playerSide != playerSide) return;

        if (abilitySystem.ability[abilityId].upgradePath == 0) abilitySystem.ability[abilityId].upgradePath = upgradeOption;
        else abilitySystem.ability[abilityId].subUpgradePath = upgradeOption;
    }
}
