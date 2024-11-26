using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string boolName) : base(player, stateMachine, boolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerMovementCompo.MovementEvent += HandleMovementEvent;
    }

    public override void Exit()
    {
        _player.PlayerMovementCompo.MovementEvent -= HandleMovementEvent;
        base.Exit();
    }

    public void HandleMovementEvent(Vector2 velocity)
    {
        float inputThreshold = 0.1f;

        if (velocity.sqrMagnitude > inputThreshold)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Run);
        }
    }
}
