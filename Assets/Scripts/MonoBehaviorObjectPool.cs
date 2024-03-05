using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class MonoBehaviorObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    public IObjectPool<T> pool;
    public abstract T prefab { get; }
    public abstract Transform parent { get; }

    protected List<T> activeObjects = new List<T>();

    public virtual void Init()
    {
        pool = new ObjectPool<T>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, 7, 10);
    }

    protected virtual T CreatePooledItem()
    {
        var item = Instantiate(prefab, parent);
        item.gameObject.SetActive(false);
        return item;
    }

    protected virtual void OnTakeFromPool(T item)
    {
        item.gameObject.SetActive(true);
        activeObjects.Add(item);
    }

    protected virtual void OnReturnedToPool(T item)
    {
        item.gameObject.SetActive(false);
        activeObjects.Remove(item);
    }

    protected virtual void OnDestroyPoolObject(T item)
    {
        GameObject.Destroy(item.gameObject);
    }

    public void ClearPool()
    {
        for (int i = activeObjects.Count - 1; i >= 0; i--)
        {
            T item = activeObjects[i];
            pool.Release(item);
        }
        activeObjects.Clear();
    }
}
