using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPooler : ObjectPooller<Entity>
{
    //private PathCreator pathLine;
    private bool isRightSidePlayer;

    public EntityPooler(Entity prefab, Transform container, int count, bool isRightSidePlayer = false) : base(prefab, container)
    {
        //this.pathLine = pathLine;
        this.isRightSidePlayer = isRightSidePlayer;

        CreatePool(count);
    }

    public override Entity CreateObject(bool isActiveByDefault = false)
    {
        Entity createdObject = Object.Instantiate(prefab, container);
        createdObject.Initialize(isRightSidePlayer);
        createdObject.gameObject.SetActive(isActiveByDefault);
        pool.Add(createdObject);
        return createdObject;
    }
}
