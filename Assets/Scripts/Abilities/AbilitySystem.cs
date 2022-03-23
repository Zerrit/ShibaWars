using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class AbilitySystem : MonoBehaviour
{
    public MainTower tower;

    [Header("Abilities")]
    [SerializeField]
    public List<Ability> ability;

    private int chosenAbility = -1;

    private void Start()
    {
        FillButtonData();
    }

    public void Update()
    {
        ApplyAbility();
    }

    private void ApplyAbility()
    {
        if (chosenAbility != -1 && Input.GetMouseButtonDown(0) && Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 15)
        {
            if(ability[chosenAbility].UseAbility(Input.mousePosition))
            {
                ability[chosenAbility].button.StartCooldown();
                tower.PayMana(ability[chosenAbility].parameters.cost);
                chosenAbility = -1;
            }      
        } 
    }

    public void ActiveAbility(int number)
    {
        if (chosenAbility == number)
        {
            chosenAbility = -1;
        }
        else
        {
            if(ability[((int)number)].parameters.cost <= tower.mana && !ability[(int)number].button.onCooldown)
            {
                chosenAbility = number;
            }
        }
        
    }


    private void FillButtonData()
    {
        for (int i = 0; i < 2; i++)
        {
            ability[i].button = tower.buttonManager.abilityButtons[i];
        }

        foreach (Ability abil in ability)
        {
            abil.button.button.image.sprite = abil.parameters.buttonIcone;
            abil.button.price.text = abil.parameters.cost.ToString();
            abil.button.cooldown = abil.parameters.cooldown;
            abil.button.cost = abil.parameters.cost;

            abil.button.firstPathText = abil.parameters.firstPath;
            abil.button.firstPathFirstUpgradeText = abil.parameters.firstPathFirstUpgrade;
            abil.button.firstPathSecondUpgradeText = abil.parameters.firstPathSecondUpgrade;

            abil.button.secondPathText = abil.parameters.secondPath;
            abil.button.secondPathFirstUpgradeText = abil.parameters.secondPathFirstUpgrade;
            abil.button.secondPathSecondUpgradeText = abil.parameters.secondPathSecondUpgrade;

            abil.button.button.onClick.AddListener(() => ActiveAbility(abil.button.buttonId));
        }
    }
}
