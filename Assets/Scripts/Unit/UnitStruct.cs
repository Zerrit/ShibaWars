using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UnitStruct 
{
    public Entity unit;
    public ButtonParameters buttonParameters;
    public ObjectPooller<Entity> pool;
}

