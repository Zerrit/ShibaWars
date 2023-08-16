using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ResourcesSystem : MonoBehaviour
{
    public int startGold, startEnergy;
    public int goldPassiveIncoming, energyPassiveIncoming;
    public int goldWorkerIncoming;
    public int Gold { get; private set; }
    public int Energy { get; private set; }
    public int MaxWorkers { get; private set; }
    public int CurrentWorkers { get; private set; }

    private float lastIncomingTime = 0;

    private void OnEnable()
    {
        EventsManager.instance.OnGoldIncrease += IncreaseGold;
        EventsManager.instance.OnEnergyIncrease += IncreaseEnergy;
        EventsManager.instance.OnGoldReduce += SpendGold;
        EventsManager.instance.OnEnergyReduce += SpendEnergy;
        EventsManager.instance.OnWorkerAdd += AddWorker;
        EventsManager.instance.OnMineTaken += AddMaxWorkers;
        EventsManager.instance.OnMineLost += RemoveMaxWorkers;

        CurrentWorkers = 0;
        MaxWorkers = 0;
    }

    private void OnDisable()
    {
        print("Выключение объекта");
        EventsManager.instance.OnGoldIncrease -= IncreaseGold;
        EventsManager.instance.OnEnergyIncrease -= IncreaseEnergy;
        EventsManager.instance.OnGoldReduce -= SpendGold;
        EventsManager.instance.OnEnergyReduce -= SpendEnergy;
        EventsManager.instance.OnWorkerAdd -= AddWorker;
        EventsManager.instance.OnMineTaken -= AddMaxWorkers;
    }

    private void Update()
    {
        PassiveIncoming();
    }

    public void Init()
    {
        Gold = startGold; 
        Energy = startEnergy;
        EventsManager.instance.UpdateGold(Gold);
        EventsManager.instance.UpdateEnergy(Energy);
    }

    public void SpendGold(int cost)
    {
        Gold -= cost;
        EventsManager.instance.UpdateGold(Gold);
    }
    public void SpendEnergy(int cost)
    {
        Energy -= cost;
        EventsManager.instance.UpdateEnergy(Energy);
    }

    public void IncreaseGold(int amount)
    {
        Gold += amount;
        EventsManager.instance.UpdateGold(Gold);
    }
    public void IncreaseEnergy(int amount)
    {
        Energy += amount;
        EventsManager.instance.UpdateEnergy(Energy);
    }

    public void AddWorker()
    {
        CurrentWorkers = Mathf.Clamp(++CurrentWorkers, 0, MaxWorkers);
        EventsManager.instance.UpdateWorkersData(CurrentWorkers, MaxWorkers);
    }
    public void AddMaxWorkers()
    {
        MaxWorkers += 3;
        EventsManager.instance.UpdateWorkersData(CurrentWorkers, MaxWorkers);
    }
    public void RemoveMaxWorkers()
    {
        MaxWorkers -= 3;

        if (CurrentWorkers > MaxWorkers) CurrentWorkers = MaxWorkers;

        EventsManager.instance.UpdateWorkersData(CurrentWorkers, MaxWorkers);
    }

    private void PassiveIncoming()
    {
        if(Time.time >= lastIncomingTime + 2.0f)
        {
            EventsManager.instance.IncreaseGold(CurrentWorkers * goldWorkerIncoming + goldPassiveIncoming);
            EventsManager.instance.IncreasesEnergy(energyPassiveIncoming);
            lastIncomingTime = Time.time;
        }
    }
}
