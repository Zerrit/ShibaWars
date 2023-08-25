using UnityEngine;

public class UnitsSpawner
{
    private UnitTemplate[] _units;

    public UnitsSpawner(UnitTemplate[] units, Transform poolTransform, Side side)
    {
        this._units = units;
        CreateUnitPools(poolTransform, side);
    }

    public void Subscribe()
    {
        EventsManager.instance.OnUnitCreate += CreateUnit;
    }
    public void Unsubscribe()
    {
        EventsManager.instance.OnUnitCreate -= CreateUnit;
    }



    private void CreateUnitPools(Transform poolTransform, Side side)
    {
        for (int i = 0; i < _units.Length; i++)
        {
            _units[i].pool = new EntityPooler(_units[i].unit, poolTransform, 4 - i, side);
        }
    }

    public void CreateUnit(int unitNumber)
    {
        Unit unit = _units[unitNumber].pool.GetFreeElement();
        BattleCommunicator.instance.AddUnit(unit);
    }
}
