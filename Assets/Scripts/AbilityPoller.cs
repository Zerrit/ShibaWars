using UnityEngine;

public class AbilityPoller : ObjectPooller<Ability>
{
    private Side side;

    public AbilityPoller(Ability prefab, Transform container, int count,Side side, bool isAutoExpend = true) : base(prefab, container, count, isAutoExpend)
    {
        this.side = side;
    }

    public override Ability CreateObject(bool isActiveByDefault = false)
    {
        Ability createdObject = Object.Instantiate(prefab, container);
        createdObject.Initialize(side);
        createdObject.gameObject.SetActive(isActiveByDefault);
        pool.Add(createdObject);
        return createdObject;
    }
}
