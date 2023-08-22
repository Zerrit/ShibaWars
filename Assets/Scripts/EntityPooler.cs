using UnityEngine;

public class EntityPooler : ObjectPooller<Unit>
{
    private PlayerSide side;

    public EntityPooler(Unit prefab, Transform container, int count, PlayerSide side, bool isAutoExpand = true) : base(prefab, container, isAutoExpand)
    {
        this.side = side;

        CreatePool(count);
    }

    public override Unit CreateObject(bool isActiveByDefault = false)
    {
        Unit createdObject = Object.Instantiate(prefab, container);
        createdObject.Initialize(side);
        createdObject.gameObject.SetActive(isActiveByDefault);
        pool.Add(createdObject);
        return createdObject;
    }
}
