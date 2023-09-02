using UnityEngine;
using UnityEngine.EventSystems;

public  class AbilityCaster : IPointerClickHandler
{
    private AbilityTemplate[] _abilities;
    
    private bool _isAbilityChosen = false;
    private int _chosenAbility;

    public AbilityCaster(AbilityTemplate[] abilities, Transform poolTransform, Side side)
    {
        this._abilities = abilities;
        CreateAbilityPools(poolTransform, side);
    }

    public void Subscribe()
    {
        EventsManager.instance.OnAbilitySelect += SelectAbility;
        EventsManager.instance.OnBattlefieldTouch += ApplyAbility;
    }
    public void Unsubscribe()
    {
        EventsManager.instance.OnAbilitySelect -= SelectAbility;
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        ApplyAbility(Camera.main.ScreenToWorldPoint(eventData.position));
    }

    private void CreateAbilityPools(Transform poolTransform, Side side)
    {
        for (int i = 0; i < _abilities.Length; i++)
        {
            _abilities[i].pool = new AbilityPoller(_abilities[i].ability, poolTransform, 1, side);
        }
    }

    public void SelectAbility(int number)
    {
        if (number == _chosenAbility && _isAbilityChosen)
        {
            _isAbilityChosen = false;
        }
        else
        {
            _isAbilityChosen = true;
            _chosenAbility = number;
        }
    }

    public void ApplyAbility(Vector2 touchPos)
    {
        if (_isAbilityChosen && touchPos.y > -8)
        {
            if(_abilities[_chosenAbility].pool.HasFreeElement(out Ability ability))
            {
                if (ability.SelectTarget(touchPos))
                {
                    ability.gameObject.SetActive(true);
                    ability.UseAbility();
                    _isAbilityChosen = false;
                    EventsManager.instance.CastAbility(_chosenAbility);
                }
            }     
        } 
    }

}
