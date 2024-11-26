using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerGroundState
{
    public PlayerFallState(Player player, PlayerStateMachine stateMachine, string boolName) : base(player, stateMachine, boolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_player.PlayerMovementCompo.IsGround == true)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }
    }
}
