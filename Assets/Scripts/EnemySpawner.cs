using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    CountDisplayManagement countDisplay;

    [SerializeField]
    ScoreManagement scoreManagement;

    [SerializeField]
    Enemy[] Enemies;

    [SerializeField]
    float SpawnTime;

    [SerializeField]
    float SpawnTime2;

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
    void FixedUpdate()
    {
        SpawnTime -= Time.deltaTime;
        SpawnTime2 -= Time.deltaTime;
        if(SpawnTime<=0)
        {
            SpawnTime = 4;
            Spawn(Enemies[0].p_EnemyNum);
        }
        if (SpawnTime2 <= 0)
        {
            Spawn(Enemies[1].p_EnemyNum);
            SpawnTime2 = 6;
        }
    }

    public void Spawn(int enemynum)
    {
        if (!EnemyPools.TryGetValue(enemynum, out var pool))
        {
            return;
        }

        Enemy enemy = pool.Get();
        enemy.transform.position = new Vector2(15f,-0.5f);
        enemy.Initialize(c => OnCoinReturned(c, pool));
    }

    private void OnCoinReturned(Enemy enemy, ObjectPool<Enemy> pool)
    {
        pool.Return(enemy);
        StartCoroutine(countDisplay.CountUpDisplay());
        scoreManagement.CountAdd();
    }
}
