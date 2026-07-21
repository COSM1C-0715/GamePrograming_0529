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

    Vector3 MoveDir = new Vector3(1.0f, 0.0f,0.0f);

    const float MaxLife = 100f;

    ReactiveProperty<float> life = new ReactiveProperty<float>(MaxLife);

    Action<float,float> OnUpdateLifeGauge;

    Action OnJudge;

    public float _MaxLife => MaxLife;

    InputSystem_Actions action;

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
    void OnJudgePoint(InputAction.CallbackContext cont)
    {
        if(cont.started)
        {
            OnJudge();
        }
    }

    public void OnActionMesod_Float(Action<float, float> l_updategauge)
    {
        OnUpdateLifeGauge = l_updategauge;
    }

    public void OnJudgeMethod(Action l_judge)
    {
        OnJudge = l_judge;
    }

    public void SubPlayerHp()
    {
        life.Value--;
    }

    public void PlayerMove()
    {
        transform.position = transform.position + (MoveDir.normalized * speed) * Time.deltaTime;
    }

}
