using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int EnemyNum;

    [SerializeField]
    int Speed;

    Vector3 InputVec = new Vector3(-1,0,0);

    public int p_EnemyNum => EnemyNum;

    public int p_Speed => Speed;

    public double TargetdespTime {  get;  set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (InputVec.normalized * Speed) * Time.deltaTime;
    }
}
