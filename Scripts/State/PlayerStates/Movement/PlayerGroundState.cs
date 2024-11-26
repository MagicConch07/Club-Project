using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player player, PlayerStateMachine stateMachine, string boolName) : base(player, stateMachine, boolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.PlayerMovementCompo._inputReader.OnAttackEvent += HandleAttack;
        _player.PlayerMovementCompo._inputReader.OnStartChargeEvent += HandleStartCharge;
    }

    private void HandleAttack()
    {
        if (_player.PlayerMovementCompo.IsGround)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Attack);
        }
    }

    private void HandleStartCharge()
    {
        if (_player.PlayerMovementCompo.IsGround)
        {
            _stateMachine.ChangeState(PlayerStateEnum.StartCharge);
        }
    }

    public override void Exit()
    {
        _player.PlayerMovementCompo._inputReader.OnAttackEvent -= HandleAttack;
        _player.PlayerMovementCompo._inputReader.OnStartChargeEvent -= HandleStartCharge;
        base.Exit();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_player.PlayerMovementCompo.isCharge) return;

        if (_player.PlayerMovementCompo.IsJump)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Jump);
        }
        else if (_player.PlayerMovementCompo.IsGround == false)
        {
            _stateMachine.ChangeState(PlayerStateEnum.Fall);
        }
    }
}