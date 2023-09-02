using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EventsManager
{
    [SerializeField]
    public static EventsManager instance;

    public EventsManager()
    {
        instance = this;
    }

    public delegate void EmptyEventHandler();
    public delegate void EventHandler(int paramValue);
    public delegate void DoubleParamsEventHandler(int firstParam, int secondParam);
    public delegate void BoolEventHandler(bool condition);
    public delegate void PositionEventHandler(Vector2 position);


    public event PositionEventHandler OnBattlefieldTouch;
    // Event нажатия кнопки создания рабочего
    public event EmptyEventHandler OnWorkerAdd;
    public event EmptyEventHandler OnMineTaken, OnMineLost;
    public event DoubleParamsEventHandler OnWorkersUpdate;

    // Events нажатия кнопок спавна юнитов и каста способностей
    public event EventHandler OnUnitCreate, OnAbilitySelect, OnAbilityCast;

    // Events обновления UI ресурсов
    public event EventHandler OnGoldUpdate, OnEnergyUpdate;

    // Events прибавки ресурсов
    public event EventHandler OnGoldIncrease, OnEnergyIncrease;

    // Events траты ресурсов
    public event EventHandler OnGoldReduce, OnEnergyReduce;


    public void TouchBattlefield(Vector2 position)
    {
        OnBattlefieldTouch?.Invoke(position);
    }

    public void AddWorker()
    {
        OnWorkerAdd?.Invoke();
    }
    public void TakeMine()
    {
        OnMineTaken?.Invoke();
    }
    public void LostMine()
    {
        OnMineLost?.Invoke();
    }

    public void CreateUnut(int value)
    {
        OnUnitCreate?.Invoke(value);
    }
    public void CastAbility(int value)
    {
        OnAbilityCast?.Invoke(value);
    }
    public void SelectAbility(int abilityId)
    {
        OnAbilitySelect?.Invoke(abilityId);
    }


    public void IncreaseGold(int changeValue)
    {
        OnGoldIncrease?.Invoke(changeValue);
    }
    public void IncreasesEnergy(int changeValue)
    {
        OnEnergyIncrease?.Invoke(changeValue);
    }

    public void ReduceGold(int changeValue)
    {
        OnGoldReduce?.Invoke(changeValue);
    }
    public void ReduceEnergy(int changeValue)
    {
        OnEnergyReduce?.Invoke(changeValue);
    }


    // Функции обновления UI ресурсов
    public void UpdateGold(int goldValue)
    {
        OnGoldUpdate?.Invoke(goldValue);
    }
    public void UpdateEnergy(int energyValue)
    {
        OnEnergyUpdate?.Invoke(energyValue);
    }
    public void UpdateWorkersData(int currentWorkers, int maxWorkers)
    {
        OnWorkersUpdate?.Invoke(currentWorkers, maxWorkers);
    }
}
