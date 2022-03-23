using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRain : Ability
{
    public ArrowRainObject arrowRain;
    public PathCreator pathCreator;

    [Header("Дополнительные параметры")]
    public int damage;
    public LayerMask enemyLayer;


    public override bool UseAbility(Vector2 touchPoint)
    {
        Vector2 way = pathCreator.path.GetClosestPointOnPath(Camera.main.ScreenToWorldPoint(touchPoint));
        Instantiate(arrowRain, way, Quaternion.identity);

        return true;
    }
}