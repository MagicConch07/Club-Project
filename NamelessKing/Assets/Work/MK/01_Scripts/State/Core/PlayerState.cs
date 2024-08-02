using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerStateMachine _stateMachine;
    protected Player _player;

    protected int _animBoolHash;
    protected bool _animEndTrigger = false;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string boolName)
    {
        _player = player;
        _stateMachine = stateMachine;
        _animBoolHash = Animator.StringToHash(boolName);
    }

    public virtual void Enter()
    {
        // 현재 상태로 들어올 때 실행되는 함수
        _player.AnimatorCompo.SetBool(_animBoolHash, true);  // 애니메이션 True
        _animEndTrigger = false;  // 트리거 False 초기화
    }

    public virtual void UpdateState()
    {
        // 현재 상태에서 반복될 함수
    }

    public virtual void Exit()
    {
        // 현재 상태에서 벗어날 때 실행되는 함수
        _player.AnimatorCompo.SetBool(_animBoolHash, false);  // 애니메이션 False
    }

    public virtual void AnimationFinshTrigger()
    {
        _animEndTrigger = true;  // 애니메이션 끝남
    }

}
