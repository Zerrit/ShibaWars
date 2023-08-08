using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability: ScriptableObject
{
    [Header("—сылки")]
    public ButtonParameters buttonParameters;

    public abstract bool UseAbility(Vector2 touchPoint);
    
}
