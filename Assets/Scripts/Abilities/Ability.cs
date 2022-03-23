using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public enum AbilityType
    {
        common,
        rare,
        epic
    }
    public AbilityType abilityType;

    public int upgradePath = 0;
    public int subUpgradePath = 0;

    [Header("—сылки")]
    public ButtonParameters parameters;
    public ButtonController button;



    public abstract bool UseAbility(Vector2 touchPoint);
    
}
