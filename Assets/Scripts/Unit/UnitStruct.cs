using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UnitStruct 
{
    public Entity unit;
    public ButtonController unitButton;
    public ButtonParameters unitParameters;
    public int upgradePath;
    public int subUpgradePath;
}

