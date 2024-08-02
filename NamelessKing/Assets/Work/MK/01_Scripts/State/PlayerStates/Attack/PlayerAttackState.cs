using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerGroundState
{
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string boolName) : base(player, stateMachine, boolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerMovementCompo.IsAttack = true;
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
        _player.PlayerMovementCompo.IsAttack = false;
        base.Exit();
    }

    public override void AnimationFinshTrigger()
    {
        base.AnimationFinshTrigger();
    }
}
