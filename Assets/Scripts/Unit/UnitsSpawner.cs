using System.Collections;
using UnityEngine;

public class UnitsSpawner: MonoBehaviour
{
    public UnitTemplate[] units;
    public Transform unitPoolTransform;


    private void Start()
    {
        InitUnitPools();
    }

    private void OnEnable()
    {
        EventsManager.instance.OnUnitCreate += CreateUnit;
    }
    private void OnDisable()
    {
        EventsManager.instance.OnUnitCreate -= CreateUnit;
    }



    private void InitUnitPools()
    {
        for (int i = 0; i < units.Length; i++)
        {
            units[i].pool = new EntityPooler(units[i].unit, unitPoolTransform, 4 - i, PlayerSide.leftPlayer);
        }
    }

    public void CreateUnit(int unitNumber)
    {
        Unit unit = units[unitNumber].pool.GetFreeElement();
        BattleCommunicator.instance.AddUnit(unit);
    }
}
