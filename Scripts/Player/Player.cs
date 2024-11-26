using LJS;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateEnum
{
    Idle,
    Run,
    Fall,
    Jump,
    Attack,
    StartCharge,
    MaxCharge,
    ChargeAttack,
    Hit,
    //Die

}

public class Player : MonoBehaviour
{
    #region Component List
    public Animator AnimatorCompo { get; private set; }
    public PlayerMovement PlayerMovementCompo { get; private set; }
    #endregion

    [Header("Basic Stats")]
    public float moveSpeed = 5f;
    public float jumpPower = 10f;

    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerHealth PlayerHealthCompo { get; private set; }

    public void ComponentInitalize()
    {
        Transform visual = transform.Find("Visual");
        AnimatorCompo = visual.GetComponent<Animator>();
        PlayerMovementCompo = GetComponent<PlayerMovement>();
        PlayerHealthCompo = GetComponent<PlayerHealth>();
    }

    void Awake()
    {
        PlayerMovementCompo = GetComponent<PlayerMovement>();
        PlayerHealthCompo = GetComponent<PlayerHealth>();
        Transform visual = transform.Find("Visual");
        AnimatorCompo = visual.GetComponent<Animator>();

        StateMachine = new PlayerStateMachine();

        foreach (PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = stateEnum.ToString();

            try
            {
                Type t = Type.GetType($"Player{typeName}State");  // 타입 가져오기
                PlayerState state = Activator.CreateInstance(
                    t, this, StateMachine, typeName) as PlayerState;
                StateMachine.AddState(stateEnum, state);  // 상태 추가
            }
            catch (Exception ex)
            {
                Debug.LogError($"{typeName} is loading Error");
                Debug.LogError(ex);
            }
        }
    }

    void Start()
    {
        StateMachine.Initalize(PlayerStateEnum.Idle, this);
    }

    public void Update()
    {
        StateMachine.CurrentState.UpdateState();  // 상태의 Update
    }

}
