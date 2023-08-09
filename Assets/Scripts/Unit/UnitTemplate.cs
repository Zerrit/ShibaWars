using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitTemplate", menuName = "Unit/UnitTemplate")]
public class UnitTemplate : ScriptableObject
{
    public Entity unit;
    public ButtonParameters buttonParameters;
    public ObjectPooller<Entity> pool;
}

