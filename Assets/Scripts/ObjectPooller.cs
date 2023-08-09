using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class ObjectPooller<T> where T : MonoBehaviour
{
    protected T prefab;
    protected bool autoExpend;
    protected Transform container;

    protected List<T> pool;

    public ObjectPooller(T prefab, Transform container, int count, bool isAutoExpend = true)
    {
        this.prefab = prefab;
        this.container = container;
        this.autoExpend = isAutoExpend;

        CreatePool(count);
    }

    public ObjectPooller(T prefab, Transform container, bool isAutoExpend = true)
    {
        this.prefab = prefab;
        this.container = container;
        this.autoExpend = isAutoExpend;
    }

    public void CreatePool(int count)
    {
        this.pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    public virtual T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(this.prefab, this.container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        this.pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var elem in pool)
        {
            if (!elem.gameObject.activeInHierarchy)
            {
                element = elem;
                elem.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element)) return element;

        if (autoExpend) return CreateObject();

        throw new System.Exception(message:$"В пуле нет свободных элементов {typeof(T)}");
    }
}
