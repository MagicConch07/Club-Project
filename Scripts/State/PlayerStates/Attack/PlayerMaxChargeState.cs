using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class PlayerMaxChargeState : PlayerGroundState
{
    public PlayerMaxChargeState(Player player, PlayerStateMachine stateMachine, string boolName) : base(player, stateMachine, boolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerMovementCompo._inputReader.OnMaxChargeEvent += HadleMaxChargeEvent;
        _player.PlayerMovementCompo.MoveSlow(true, 3f);

    }

    public override void Exit()
    {
        _player.PlayerMovementCompo._inputReader.OnMaxChargeEvent -= HadleMaxChargeEvent;
        _player.PlayerMovementCompo.MoveSlow(false);
        base.Exit();
    }

    private void HadleMaxChargeEvent(bool IsMax)
    {
        if (IsMax == false)  // charge가 max인데 우클릭을 뗀 상태면 공격 실행
        {
            _stateMachine.ChangeState(PlayerStateEnum.ChargeAttack);
        }
    }
}
