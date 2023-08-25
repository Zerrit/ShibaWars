using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class ResourcesSystem
{
    public int _gold, _energy;
    private int _goldPassiveIncoming, _energyPassiveIncoming;
    private int _goldWorkerIncoming;
    private int _currentWorkers, _maxWorkers;

    private float lastIncomingTime;

    public ResourcesSystem(int startGold, int startEnergy, int goldPassiveIncoming, int energyPassiveIncoming, int goldWorkerIncoming)
    {
        this._gold = startGold;
        this._energy = startEnergy;
        this._goldPassiveIncoming = goldPassiveIncoming;
        this._energyPassiveIncoming = energyPassiveIncoming;
        this._goldWorkerIncoming = goldWorkerIncoming;

        EventsManager.instance.UpdateGold(_gold);
        EventsManager.instance.UpdateEnergy(_energy);

        _currentWorkers = 0;
        _maxWorkers = 0;
        lastIncomingTime = 0;
    }

    public void Subscribe()
    {
        EventsManager.instance.OnGoldIncrease += IncreaseGold;
        EventsManager.instance.OnEnergyIncrease += IncreaseEnergy;
        EventsManager.instance.OnGoldReduce += SpendGold;
        EventsManager.instance.OnEnergyReduce += SpendEnergy;
        EventsManager.instance.OnWorkerAdd += AddWorker;
        EventsManager.instance.OnMineTaken += AddMaxWorkers;
        EventsManager.instance.OnMineLost += RemoveMaxWorkers;
    }
    public void Unsubscribe()
    {
        EventsManager.instance.OnGoldIncrease -= IncreaseGold;
        EventsManager.instance.OnEnergyIncrease -= IncreaseEnergy;
        EventsManager.instance.OnGoldReduce -= SpendGold;
        EventsManager.instance.OnEnergyReduce -= SpendEnergy;
        EventsManager.instance.OnWorkerAdd -= AddWorker;
        EventsManager.instance.OnMineTaken -= AddMaxWorkers;
        EventsManager.instance.OnMineLost -= RemoveMaxWorkers;
    }

    public void SpendGold(int cost)
    {
        _gold -= cost;
        EventsManager.instance.UpdateGold(_gold);
    }
    public void SpendEnergy(int cost)
    {
        _energy -= cost;
        EventsManager.instance.UpdateEnergy(_energy);
    }

    public void IncreaseGold(int amount)
    {
        _gold += amount;
        EventsManager.instance.UpdateGold(_gold);
    }
    public void IncreaseEnergy(int amount)
    {
        _energy += amount;
        EventsManager.instance.UpdateEnergy(_energy);
    }

    public void AddWorker()
    {
        _currentWorkers = Mathf.Clamp(++_currentWorkers, 0, _maxWorkers);
        EventsManager.instance.UpdateWorkersData(_currentWorkers, _maxWorkers);
    }
    public void AddMaxWorkers()
    {
        _maxWorkers += 3;
        EventsManager.instance.UpdateWorkersData(_currentWorkers, _maxWorkers);
    }
    public void RemoveMaxWorkers()
    {
        _maxWorkers -= 3;

        if (_currentWorkers > _maxWorkers) _currentWorkers = _maxWorkers;

        EventsManager.instance.UpdateWorkersData(_currentWorkers, _maxWorkers);
    }

    public void PassiveIncoming()
    {
        if(Time.time >= lastIncomingTime + 2.0f)
        {
            EventsManager.instance.IncreaseGold(_currentWorkers * _goldWorkerIncoming + _goldPassiveIncoming);
            EventsManager.instance.IncreasesEnergy(_energyPassiveIncoming);
            lastIncomingTime = Time.time;
        }
    }
}