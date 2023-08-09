using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class AbilitySystem : MonoBehaviour
{
    public MainTower tower;

    [Header("Abilities")]
    [SerializeField]
    public Ability[] abilities;

    private bool isAbilityChosen = false;
    private int chosenAbility;

    public void Update()
    {
        ApplyAbility();
    }

    private void ApplyAbility()
    {
        if (chosenAbility != -1 && Input.GetMouseButtonDown(0) && Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 15)
        {
            if(abilities[chosenAbility].UseAbility(Input.mousePosition))
            {
                //abilities[chosenAbility].button.StartCooldown();
                //tower.PayMana(abilities[chosenAbility].buttonParameters.cost);
                chosenAbility = -1;
            }      
        } 
    }

    public void ActiveAbility(int number)
    {
        if (isAbilityChosen)
        {
            isAbilityChosen = false;
        }
        else
        {
/*            if(abilities[((int)number)].buttonParameters.cost <= tower.mana && !abilities[(int)number].button.onCooldown)
            {
                chosenAbility = number;
                isAbilityChosen = true;
            }*/
        }
        
    }

}
