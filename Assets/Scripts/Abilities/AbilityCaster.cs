using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class AbilityCaster : MonoBehaviour
{
    [Header("Abilities")]
    public AbilityTemplate[] abilities;

    public Transform abilityPoolTransform;
    private bool isAbilityChosen = false;
    private int chosenAbility;


    private void OnEnable()
    {
        EventsManager.instance.OnAbilitySelect += SelectAbility;
        InitAbilityPools();
    }
    private void OnDisable()
    {
        EventsManager.instance.OnAbilitySelect -= SelectAbility;
    }
    public void Update()
    {
        ApplyAbility();
    }


    private void InitAbilityPools()
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            abilities[i].pool = new AbilityPoller(abilities[i].ability, abilityPoolTransform, 1, PlayerSide.leftPlayer);
        }
    }

    public void SelectAbility(int number)
    {
        if (number == chosenAbility && isAbilityChosen)
        {
            isAbilityChosen = false;
        }
        else
        {
            isAbilityChosen = true;
            chosenAbility = number;
            print("Выбрана способность" + abilities[number].ToString());
        }
    }

    private void ApplyAbility()
    {
        if (isAbilityChosen && Input.GetMouseButtonDown(0) && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -8)
        {
            if(abilities[chosenAbility].pool.HasFreeElement(out Ability ability))
            {
                if (ability.SelectTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
                {
                    ability.gameObject.SetActive(true);
                    ability.UseAbility();
                    isAbilityChosen = false;
                    EventsManager.instance.CastAbility(chosenAbility);
                }
            }     
        } 
    }
}
