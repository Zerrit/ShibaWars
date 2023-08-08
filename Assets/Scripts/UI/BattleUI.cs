using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    public PlayerSide playerSide;


    [Header("UI")]
    public TextMeshProUGUI goldScore;
    public TextMeshProUGUI manaScore;

    public Transform actionButtonPanel;
    public ButtonController actionButton;

    //public UpgradePanelController upgradePanelController;
    //public UIEvents events;

    //public MainTower tower;
    //public AbilitySystem abilitySystem;


    //public ButtonController[] unitButtons;
    //public ButtonController[] abilityButtons;
    //public ButtonController workerButton;

    private void Start()
    {
        //events = GetComponent<UIEvents>();

        //events.playerSide = playerSide;
       // upgradePanelController.events = events;


/*        for (int i = 0; i < unitButtons.Length; i++)
        {
            unitButtons[i].buttonId = i;
            unitButtons[i].isAbility = false;
        }

        for (int i = 0; i < abilityButtons.Length; i++)
        {
            abilityButtons[i].buttonId = i;
            abilityButtons[i].isAbility = true;
        }*/
    }



    public void InitializeUnitButtons(UnitsSpawner unitSpawner)
    {
        int unitId = 0;
        foreach (UnitStruct unit in unitSpawner.unitsData)
        {
            ButtonController button = Instantiate(actionButton, actionButtonPanel);
            button.button.image.sprite = unit.buttonParameters.buttonIcone;
            button.cost.text = unit.buttonParameters.cost.ToString();
            button.cooldown = unit.buttonParameters.cooldown;
            button.price = unit.buttonParameters.cost;
            unit.buttonParameters.id = unitId;

            button.button.onClick.AddListener(() => unitSpawner.CreateUnit(unit.buttonParameters.id));
            unitId++;
        }
    }

    public void InitializeAbilityButtons(AbilitySystem abilitySystem)
    {
        int abilityId = 0;
        foreach (Ability ability in abilitySystem.abilities)
        {
            ButtonController button = Instantiate(actionButton, actionButtonPanel);
            button.button.image.sprite = ability.buttonParameters.buttonIcone;
            button.cost.text = ability.buttonParameters.cost.ToString();
            button.cooldown = ability.buttonParameters.cooldown;
            button.price = ability.buttonParameters.cost;
            ability.buttonParameters.id = abilityId;

            button.button.onClick.AddListener(() => abilitySystem.ActiveAbility(ability.buttonParameters.id));
            abilityId++;
        }
    }
}
