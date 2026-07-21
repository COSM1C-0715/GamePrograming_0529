using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    Action<Enemy> OnInputTimingMethod;

    [SerializeField]
    CountDisplayManagement countDisplay;

    [SerializeField]
    ScoreManagement scoreManagement;

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
    /// <summary>
    /// 引数に敵の番号を入れ、番号に合ったプールから敵を取り出して指定の座標に配置する
    /// </summary>
    /// <param name="enemynum"></param>
    public void Spawn(int enemynum)
    {
        Enemy enemy = EnemyPools[enemynum].Get();
        enemy.transform.position = new Vector2(-11.5f,0.0f) + new Vector2(enemy.p_Speed * 6,0.2f);
        enemy.TargetdespTime = AudioSettings.dspTime + 5;
        OnInputTimingMethod(enemy);
    }

    public void EnemyInfoMethod(Action<Enemy> l_enemymethod)
    {
        OnInputTimingMethod = l_enemymethod;
    }

    public void OnEnemyReturned(Enemy l_enemy)
    {
        EnemyPools[l_enemy.p_EnemyNum].Return(l_enemy);
        StartCoroutine(countDisplay.CountUpDisplay());
        scoreManagement.CountAdd();
    }
}
