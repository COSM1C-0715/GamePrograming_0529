using UnityEngine;
using System.Collections.Generic;
using System;

public class EnemynumAndTimingManager : MonoBehaviour
{
    [SerializeField] EnemySpawner Spawner;

    [SerializeField] Player player;

    Queue<Enemy> EnemyInfo = new Queue<Enemy>();

    const double MissTiming = 1.3;

    const double KillTiming = 1.1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawner.EnemyInfoMethod(InputEnemyTiming);
        player.OnJudgeMethod(PlayerHitJudge);
    }

    // Update is called once per frame
    void Update()
    {
        Judge();
    }

    void InputEnemyTiming(Enemy l_enemy)
    {
        EnemyInfo.Enqueue(l_enemy);
    }

    void Judge()
    {
        if (EnemyInfo.Count  == 0) return;

        double currenttiming = AudioSettings.dspTime;

        double timesub = currenttiming - EnemyInfo.Peek().TargetdespTime;

        if (timesub > MissTiming)
        {
            Debug.Log("Miss");
            Enemy enemy = EnemyInfo.Dequeue();
            Spawner.OnEnemyReturned(enemy);
            player.SubPlayerHp();
        }
    }

    void PlayerHitJudge()
    {
        if (EnemyInfo.Count == 0) return;

        double currenttiming = AudioSettings.dspTime;

        double timesub = Math.Abs(currenttiming - EnemyInfo.Peek().TargetdespTime);

        if (timesub <= KillTiming)
        {
            Debug.Log("Kill");
            Enemy enemy = EnemyInfo.Dequeue();
            Spawner.OnEnemyReturned(enemy);
        }
    }
}
