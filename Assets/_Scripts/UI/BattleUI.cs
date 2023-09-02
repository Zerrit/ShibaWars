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
    public UnitButton[] unitButtons;
    public AbilityButton[] abilityButtons;


    private void Subscribe()
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


    public void Initialize(ButtonParameters workerParameters, UnitTemplate[] units, AbilityTemplate[] abilities)
    {
        ConfigureButton(workerButton, workerParameters, 0);

        if(units.Length != 0)
        {
            for(int i = 0; i < units.Length; i++)
            {
                ConfigureButton(unitButtons[i], units[i].buttonParameters, i);
            }
        }

        if (abilities.Length != 0)
        {
            for (int i = 0; i < abilities.Length; i++)
            {
                ConfigureButton(abilityButtons[i], abilities[i].buttonParameters, i);
            }
        }

        Subscribe();
    }


    private void ConfigureButton(ButtonController button, ButtonParameters buttonParameters, int buttonId)
    {
        button.button.image.sprite = buttonParameters.buttonIcone;
        button.cooldown = buttonParameters.cooldown;
        button.cost = buttonParameters.cost;
        button.costText.text = button.cost.ToString();
        button.buttonId = buttonId;
        button.gameObject.SetActive(true);
        button.Initialize();
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
