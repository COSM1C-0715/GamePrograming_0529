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
    float timer = 0;


    [SerializeField]
    private int InitialPoolSize;

    private Dictionary<int, ObjectPool<Enemy>> EnemyPools = new();
    Queue<Enemy> EnemyTiming = new();

    public Queue<Enemy> P_EnemyTiming => EnemyTiming;
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
        timer = Time.time;
    }
    /// <summary>
    /// 引数に敵の番号を入れ、番号に合ったプールから敵を取り出して指定の座標に配置する
    /// </summary>
    /// <param name="enemynum"></param>
    public void Spawn(int enemynum)
    {
        if (!EnemyPools.TryGetValue(enemynum, out var pool))
        {
            return;
        }
        Debug.Log("モンスターが出てきた");
        Enemy enemy = pool.Get();
        enemy.transform.position = new Vector2(-11.5f,0.0f) + new Vector2(enemy.p_Speed * 6,0.0f);
        enemy.TargetdespTime = AudioSettings.dspTime + 5;
        EnemyTiming.Enqueue(enemy);
        enemy.Initialize(c => OnEnemyReturned(c, pool));
    }

    public void OnEnemyReturned(Enemy enemy, ObjectPool<Enemy> pool)
    {
        pool.Return(enemy);
        EnemyTiming.Dequeue();
        StartCoroutine(countDisplay.CountUpDisplay());
        scoreManagement.CountAdd();
    }
}
