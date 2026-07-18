using UnityEngine;
using System.Collections.Generic;
using System;

public class EnemynumAndTimingManager : MonoBehaviour
{
    [SerializeField] EnemySpawner Spawner;

    [SerializeField] Player player;

    Queue<Enemy> EnemyInfo;

    const double MissTiming = 0.3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawner.EnemyInfoMethod(InputEnemyTiming);
    }

    // Update is called once per frame
    void Update()
    {
        

        double currenttiming = AudioSettings.dspTime;

        double timesub = currenttiming - EnemyInfo.Peek().TargetdespTime;

        if (timesub > MissTiming)
        {
            Debug.Log("Miss");
            EnemyInfo.Dequeue();
        }
    }

    void InputEnemyTiming(Enemy l_enemy)
    {
        EnemyInfo.Enqueue(l_enemy);
    }
}
