using UnityEngine;

public class PlayerStartChargeState : PlayerGroundState
{
    public PlayerStartChargeState(Player player, PlayerStateMachine stateMachine, string boolName) : base(player, stateMachine, boolName)
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

    public override void UpdateState()
    {
        base.UpdateState();
    }

    private void HadleMaxChargeEvent(bool IsMax)
    {
        if (IsMax)
        {
            _stateMachine.ChangeState(PlayerStateEnum.MaxCharge);
        }
        else   // 우클릭을 뗀 상태이면
        {
            _stateMachine.ChangeState(PlayerStateEnum.Idle);
        }

    }
}