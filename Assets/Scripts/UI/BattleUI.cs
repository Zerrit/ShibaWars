using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    //public PlayerSide playerSide;


    [Header("UI")]
    public TextMeshProUGUI goldScore;
    public TextMeshProUGUI energyScore;

    public Transform actionButtonPanel;
    public ButtonController unitButton;
    public ButtonController abilityButton;


    private void OnEnable()
    {
        StartCoroutine(SubscribeEvent());
    }
    private void OnDisable()
    {
        EventsManager.instance.OnGoldUpdate -= UpdateGoldScore;
        EventsManager.instance.OnEnergyUpdate -= UpdateEnergyScore;
    }

    public void InitializeUnitButtons(UnitsSpawner unitSpawner)
    {
        if (unitSpawner.avalaibleUnits.Length == 0) return;

        int unitId = 0;
        foreach (UnitTemplate unit in unitSpawner.avalaibleUnits)
        {
            ButtonController button = Instantiate(unitButton, actionButtonPanel);
            button.button.image.sprite = unit.buttonParameters.buttonIcone;
            button.cooldown = unit.buttonParameters.cooldown;
            button.cost = unit.buttonParameters.cost;
            button.costText.text = button.cost.ToString();
            button.buttonId = unitId;
            unitId++;

        }
    }
    public void InitializeAbilityButtons(AbilityCaster abilityCaster)
    {
        if (abilityCaster.abilities.Length == 0) return;

        int abilityId = 0;
        foreach (Ability ability in abilityCaster.abilities)
        {
            ButtonController button = Instantiate(abilityButton, actionButtonPanel);
            button.button.image.sprite = ability.buttonParameters.buttonIcone;
            button.cooldown = ability.buttonParameters.cooldown;
            button.cost = ability.buttonParameters.cost;
            button.costText.text = button.cost.ToString();
            button.buttonId = abilityId;
            abilityId++;
        }
    }


    private void UpdateGoldScore(int value)
    {
        goldScore.text = value.ToString();
    }
    private void UpdateEnergyScore(int value)
    {
        energyScore.text = value.ToString();
    }


    private IEnumerator SubscribeEvent()
    {
        yield return new WaitUntil(() => EventsManager.instance != null);

        EventsManager.instance.OnGoldUpdate += UpdateGoldScore;
        EventsManager.instance.OnEnergyUpdate += UpdateEnergyScore;
    }

}
