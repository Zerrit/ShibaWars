using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class AbilityCaster : MonoBehaviour
{
    [Header("Abilities")]
    public Ability[] abilities;

    private bool isAbilityChosen = false;
    private int chosenAbility;

    private void OnEnable()
    {
        StartCoroutine(SubscribeEvent());
    }
    private void OnDisable()
    {
        EventsManager.instance.OnAbilitySelect -= SelectAbility;
    }

    public void Update()
    {
        ApplyAbility();
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
            if(abilities[chosenAbility].UseAbility(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
            {
                isAbilityChosen = false;
                EventsManager.instance.CastAbility(chosenAbility);
            }      
        } 
    }


    private IEnumerator SubscribeEvent()
    {
        yield return new WaitUntil(() => EventsManager.instance != null);

        EventsManager.instance.OnAbilitySelect += SelectAbility;
    }
}
