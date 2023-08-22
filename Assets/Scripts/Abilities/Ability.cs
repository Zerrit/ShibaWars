using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability: MonoBehaviour
{
    [Header("Данные")]
    public PlayerSide side;
    //public ButtonParameters buttonParameters;

    public abstract void Initialize(PlayerSide side);
    public abstract bool SelectTarget(Vector2 touchPoint);
    public abstract void UseAbility();
    
}
