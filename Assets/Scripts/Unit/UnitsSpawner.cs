using PathCreation;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitsSpawner: MonoBehaviour
{
    public MainTower tower;
    public UnitStruct[] unitsData;

    public Transform unitPoolTransform;

    private void Start()
    {
        InitUnitPools();
    }

    private void InitUnitPools()
    {
        for (int i = 0; i < unitsData.Length; i++)
        {
            unitsData[i].pool = new EntityPooler(unitsData[i].unit, unitPoolTransform, 4 - i);
        }
    }

    public void CreateUnit(int unitNumber)
    {
        //tower.PayGold(unitsData[unitNumber].unitParameters.cost);
        //unitsData[unitNumber].unitButton.StartCooldown();
        print(unitNumber);
        Entity unit = unitsData[unitNumber].pool.GetFreeElement();
        BattleCommunicator.instance.AddUnit(unit);
    }
}
