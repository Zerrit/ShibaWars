using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapIcon : MonoBehaviour
{
    public Unit entity;

    public Transform startPoint;
    public Transform endPoint;

    private float t;

    public void Update()
    {
        MoveIcon();
    }

    public void FixedUpdate()
    {
        CheckIsAlive();
    }

    private void MoveIcon()
    {
        //if(entity.playerSide == 0) t = entity.distance / entity.pathLength;
        //else t = (entity.pathLength + entity.distance) / entity.pathLength;

        gameObject.transform.position = Vector2.Lerp(startPoint.position, endPoint.position, t);
    }

    private void CheckIsAlive()
    {
        if (entity.IsDefeated)
        {
            Destroy(gameObject, 1f);
        }
    }
}
