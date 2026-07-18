using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    int EnemyNum;

    [SerializeField]
    int Speed;

    Vector2 InputVec = new Vector2(-1,0);

    public int p_EnemyNum => EnemyNum;

    public int p_Speed => Speed;

    public double TargetdespTime {  get;  set; }

    public Action<Enemy> onReturn;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = InputVec.normalized * Speed;
    }
}
