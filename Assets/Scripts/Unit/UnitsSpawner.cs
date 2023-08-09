using PathCreation;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitsSpawner: MonoBehaviour
{
    public MainTower tower;
    public UnitTemplate[] avalaibleUnits;

    public Transform unitPoolTransform;

    private void Start()
    {
        InitUnitPools();
        EventsManager.instance.OnUnitCreate += CreateUnit;
    }

    private void InitUnitPools()
    {
        for (int i = 0; i < avalaibleUnits.Length; i++)
        {
            avalaibleUnits[i].pool = new EntityPooler(avalaibleUnits[i].unit, unitPoolTransform, 4 - i);
        }
    }

    public void CreateUnit(int unitNumber)
    {
        Entity unit = avalaibleUnits[unitNumber].pool.GetFreeElement();
        BattleCommunicator.instance.AddUnit(unit);
    }
}
