using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newUnitParameters", menuName = "Unit/Unit Parameters")]
public class UnitData : ScriptableObject
{
    [Header("Health")]
    public int maxHealth = 100;

    [Header("Attack Parameters")]
    public int maxAttackRange = 15;
    public int damage = 5;

    [Header("Move Parameters")]
    public float speed;
    public int checkEnemyDistance;
}
