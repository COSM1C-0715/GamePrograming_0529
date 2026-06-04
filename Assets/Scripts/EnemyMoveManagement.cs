using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveManagement : MonoBehaviour
{
    [SerializeField]
    Enemy[] Enemies;

    [SerializeField]
    private int InitialPoolSize;

    private Dictionary<int, ObjectPool<Enemy>> EnemyPools = new();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var prefab in Enemies)
        {
            int enemynum = prefab.p_EnemyNum;
            EnemyPools[enemynum] = new ObjectPool<Enemy>(prefab, InitialPoolSize);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
