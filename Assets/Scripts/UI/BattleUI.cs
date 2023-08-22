using TMPro;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    //public PlayerSide playerSide;


    [Header("UI")]
    public TextMeshProUGUI goldScore;
    public TextMeshProUGUI energyScore;
    public TextMeshProUGUI workersCount;

    [Header("Child Panel")]
    public Transform actionButtonPanel;

    [Header("Components")]
    public WorkerButton workerButton;
    public ButtonController unitButton;
    public ButtonController abilityButton;


    private void OnEnable()
    {
        EventsManager.instance.OnGoldUpdate += UpdateGoldScore;
        EventsManager.instance.OnEnergyUpdate += UpdateEnergyScore;
        EventsManager.instance.OnWorkersUpdate += UpdateWorkers;
    }
    private void OnDisable()
    {
        EventsManager.instance.OnGoldUpdate -= UpdateGoldScore;
        EventsManager.instance.OnEnergyUpdate -= UpdateEnergyScore;
        EventsManager.instance.OnWorkersUpdate -= UpdateWorkers;
    }

    public void InitializeWorkerButton(ButtonParameters workerParams)
    {
        FillButtonData(workerButton, workerParams, 0);
    }
    public void InitializeUnitButtons(UnitsSpawner unitSpawner)
    {
        if (unitSpawner.units.Length == 0) return;

        int unitId = 0;
        foreach (UnitTemplate unit in unitSpawner.units)
        {
            ButtonController button = Instantiate(unitButton, actionButtonPanel);
            FillButtonData(button, unit.buttonParameters, unitId);
            unitId++;
        }
    }
    public void InitializeAbilityButtons(AbilityCaster abilityCaster)
    {
        if (abilityCaster.abilities.Length == 0) return;

        int abilityId = 0;
        foreach (AbilityTemplate ability in abilityCaster.abilities)
        {
            ButtonController button = Instantiate(abilityButton, actionButtonPanel);
            FillButtonData(button, ability.buttonParameters, abilityId);
            abilityId++;
        }
    }

    private void FillButtonData(ButtonController button, ButtonParameters buttonParameters, int buttonId)
    {
        button.button.image.sprite = buttonParameters.buttonIcone;
        button.cooldown = buttonParameters.cooldown;
        button.cost = buttonParameters.cost;
        button.costText.text = button.cost.ToString();
        button.buttonId = buttonId;
    }

    private void UpdateGoldScore(int value)
    {
        goldScore.text = value.ToString();
    }
    private void UpdateEnergyScore(int value)
    {
        energyScore.text = value.ToString();
    }
    private void UpdateWorkers(int currentWorkers, int maxWorkers)
    {
        workersCount.text = currentWorkers + "/" + maxWorkers;

        if (currentWorkers == maxWorkers) workerButton.isLimitReached = true;
        else workerButton.isLimitReached = false;
    }
}
