using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;

    private void Awake()
    {
        instance = this;
    }

    public delegate void EventHandler(int paramValue);

    // Events ������� ������ ������ ������ � ����� ������������
    public event EventHandler OnUnitCreate, OnAbilitySelect, OnAbilityCast;

    // Events ���������� UI ��������
    public event EventHandler OnGoldUpdate, OnEnergyUpdate;

    // Events �������� ��������
    public event EventHandler OnGoldIncrease, OnEnergyIncrease;

    // Events ����� ��������
    public event EventHandler OnGoldReduce, OnEnergyReduce;






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


    // ������� ���������� UI ��������
    public void UpdateGold(int goldValue)
    {
        OnGoldUpdate?.Invoke(goldValue);
    }
    public void UpdateEnergy(int energyValue)
    {
        OnEnergyUpdate?.Invoke(energyValue);
    }
}
