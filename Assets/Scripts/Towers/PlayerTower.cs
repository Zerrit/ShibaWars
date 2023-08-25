using UnityEngine;

public class PlayerTower : MainTower
{
    [Header("��������� ��������� ������")]
    [SerializeField] private int _startGold, _startEnergy;
    [SerializeField] private int _goldPassiveIncoming, _energyPassiveIncoming;
    [SerializeField] private int _goldWorkerIncoming;

    [Header("������ ��� �������� ��������� ����")]
    [SerializeField] private Transform _poolTransform;

    [Header("��������� ������ ����� ��������")]
    public ButtonParameters _workerParameters;
    [Header("������� ��������� ������ ������")]
    public UnitTemplate[] _units;
    [Header("������� ��������� ������ ������������")]
    public AbilityTemplate[] _abilities;

    public UnitsSpawner unitSpawner;
    public AbilityCaster abilityCaster;
    public ResourcesSystem resourcesSystem;

    public void Initialize(Side side)
    {
        if (_units != null) unitSpawner = new UnitsSpawner(_units, _poolTransform, side);
        if (_abilities != null) abilityCaster = new AbilityCaster(_abilities, _poolTransform, side);
        resourcesSystem = new ResourcesSystem(_startGold, _startEnergy, _goldPassiveIncoming, _energyPassiveIncoming, _goldWorkerIncoming);

        unitSpawner.Subscribe();
        abilityCaster.Subscribe();
        resourcesSystem.Subscribe();
    }

    private void OnDisable()
    {
        unitSpawner.Unsubscribe();
        abilityCaster.Unsubscribe();
        resourcesSystem.Unsubscribe();
    }

    public void Update()
    {
        resourcesSystem.PassiveIncoming();
    }
}