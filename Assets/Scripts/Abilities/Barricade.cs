using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : Ability
{
    public GameObject barricade;
    public PathCreator pathCreator;

    [Header("Дополнительные параметры")]
    public LayerMask barricadeLayer;
    private LayerMask spawnErrorLayer;
    

    private void Start()
    {
        SetLayerMasks();
    }

    public override bool UseAbility(Vector2 touchPoint)
    {
        Vector2 way =  pathCreator.path.GetClosestPointOnPath(Camera.main.ScreenToWorldPoint(touchPoint));
        //Vector2 way = pathCreator.path.GetCustomPointOnPath(Camera.main.ScreenToWorldPoint(touchPoint));

        Collider2D hit = Physics2D.OverlapCircle(way, 2f, spawnErrorLayer);
        if (hit == null)
        {
            GameObject bar = Instantiate(barricade, way, Quaternion.identity);
            
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetLayerMasks()
    {
        spawnErrorLayer = ~(1 << 3);
    }

}
