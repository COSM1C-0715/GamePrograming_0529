using System.Collections.Generic;
using UnityEngine;

public class PoolManagement : MonoBehaviour
{
    [SerializeField] AnyObject[] AnyObjects;

    [SerializeField] int InitialPoolSize;

    Dictionary<int, ObjectPool<AnyObject>> Pools = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var prefab in AnyObjects)
        {
            int obj = prefab.p_ObjectType;
            Pools[obj] = new ObjectPool<AnyObject>(prefab, InitialPoolSize);
        }
        for(int i = 0;i < 6;i++)
        {
            Spawn(AnyObjects[0].p_ObjectType);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn(int objecttype)
    {
        if (!Pools.TryGetValue(objecttype, out var pool))
        {
            return;
        }

        AnyObject obj = pool.Get();
        obj.Initialize(c => OnCoinReturned(c, pool));
    }

    private void OnCoinReturned(AnyObject coin, ObjectPool<AnyObject> pool)
    {
        pool.Return(coin);
    }
}
