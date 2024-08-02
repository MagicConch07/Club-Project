using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerState
{
    public PlayerHitState(Player player, PlayerStateMachine stateMachine, string boolName) : base(player, stateMachine, boolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerMovementCompo.StopImmediately();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_animEndTrigger)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void AnimationFinshTrigger()
    {
        base.AnimationFinshTrigger();
    }
}
