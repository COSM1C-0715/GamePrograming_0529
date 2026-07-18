using UnityEngine;
using UnityEngine.InputSystem;
using R3;               // R3 core
using R3.Triggers;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] EnemySpawner Spawner;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    const float MaxLife = 100f;

    ReactiveProperty<float> life = new ReactiveProperty<float>(MaxLife);

    Action<float,float> OnUpdateLifeGauge;

    public float _MaxLife => MaxLife;

    InputSystem_Actions action;

    Enemy enemy;

    void Awake()
    {
        action = new InputSystem_Actions();
        life.Subscribe(currentHP =>
        {
            life.Value = Mathf.Clamp(currentHP, 0, MaxLife);

            OnUpdateLifeGauge(currentHP, MaxLife);
        });
    }

    void OnEnable()
    {
        action.Enable();
        action.Player.Interact.started += OnJudgePoint;
    }

    void OnDisable()
    {
        action.Player.Interact.started -= OnJudgePoint;
        action.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 移動
        //var move = playerInput.actions["Move"].ReadValue<Vector2>();
        //if (move.x != 0f)
        //{
        //    rb.linearVelocityX = move.x * speed;

        //    // 向き
        //    var localScale = transform.localScale;
        //    if (move.x < 0)
        //    {
        //        localScale.x = 1f;
        //    }
        //    else
        //    {
        //        localScale.x = -1f;
        //    }
        //    transform.localScale = localScale;
        //}

        //// ジャンプ
        //if (playerInput.actions["Jump"].WasPressedThisFrame())
        //{
        //    rb.linearVelocityY = jumpSpeed;
        //}
    }
    void OnJudgePoint(InputAction.CallbackContext cont)
    {
        if(cont.started)
        {

            //if (Spawner.P_EnemyTiming.Count==0) return;

            //enemy = Spawner.P_EnemyTiming.Peek();

            //double currenttime = AudioSettings.dspTime;

            //double timediff = Math.Abs(currenttime - enemy.TargetdespTime);

            //if(timediff <=0.3f)
            //{
            //    Debug.Log("敵を倒した");
            //    enemy.onReturn?.Invoke(enemy);
            //}
            //else
            //{
            //    //enemy.onReturn?.Invoke(enemy);
            //}
        }
    }

    public void OnActionMesod_Float(Action<float, float> l_updategauge)
    {
        OnUpdateLifeGauge = l_updategauge;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            life.Value -= 10;
        }
    }
}
