using System;
using System.Collections;
using System.Collections.Generic;
using LJS;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [field: SerializeField] public AgentStat PlayerStat { get; private set; }

    public bool IsHit { get; set; } = false;

    #region Compoent
    private Player _player;
    private PlayerStateMachine _stateMachine;
    #endregion

    private void Awake()
    {
        PlayerStat = Instantiate(PlayerStat);
        PlayerStat.SetOwner(this);
        _player = GetComponent<Player>();
    }

    void Start()
    {
        // Unity Life Cycle 꼬일까봐 여기서 처리함
        _stateMachine = _player.StateMachine;
    }

    private void Update()
    {
        #region Debug
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DownHp(10f);
        }
        #endregion
    }

    public void DownHp(float downValue)
    {

        PlayerStat.AddModifier(StatType.MaxHealth, -downValue);
        if (PlayerStat.maxHealth.GetValue() <= 0)
        {
            print("DIE");
            //_stateMachine.ChangeState(PlayerStateEnum.Die);
        }
        Debug.Log($"PlayerHit");
        _stateMachine.ChangeState(PlayerStateEnum.Hit);
        IsHit = true;
    }

    public void HealHp(float healValue)
    {
        PlayerStat.AddModifier(StatType.MaxHealth, healValue);
    }
}
