using System.Collections;
using UnityEngine;

public class UnitsSpawner: MonoBehaviour
{
    public UnitTemplate[] avalaibleUnits;

    public Transform unitPoolTransform;

    private void OnEnable()
    {
        StartCoroutine(SubscribeEvent());
    }
    private void OnDisable()
    {
        EventsManager.instance.OnUnitCreate -= CreateUnit;
    }

    private void Start()
    {
        InitUnitPools();
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




    private IEnumerator SubscribeEvent()
    {
        yield return new WaitUntil(() => EventsManager.instance != null);
        EventsManager.instance.OnUnitCreate += CreateUnit;
    }
}
