using UnityEngine;
using System.Collections.Generic;

public class ObjectPool<T> where T : MonoBehaviour
{
    private readonly T Prefab;
    private readonly Queue<T> Pool = new Queue<T>();
    private readonly Transform parent;

    public ObjectPool(T Prefab, int InitialSize, Transform Parent = null)
    {
        this.Prefab = Prefab;
        this.parent = Parent;

        for (int i = 0; i < InitialSize; i++)
        {
            T obj = CreateNew();
            obj.gameObject.SetActive(false);
            Pool.Enqueue(obj);
        }
    }

    public T Get()
    {
        T obj = Pool.Count > 0 ? Pool.Dequeue() : CreateNew();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        Pool.Enqueue(obj);
    }

    private T CreateNew()
    {
        return Object.Instantiate(Prefab, parent);
    }
}