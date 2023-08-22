using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitTemplate", menuName = "Unit/UnitTemplate")]
public class UnitTemplate : ScriptableObject
{
    public Unit unit;
    public ButtonParameters buttonParameters;
    public ObjectPooller<Unit> pool;
}

