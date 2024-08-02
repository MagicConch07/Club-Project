using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerAnimation : MonoBehaviour
{
    private Player _player;
    private PlayerMovement _playerMovement;
    private SpriteRenderer _sprite;
    private bool _isFlip = false;

    void Awake()
    {
        //_sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _player = GetComponentInParent<Player>();
        _playerMovement = GetComponentInParent<PlayerMovement>();
        print(_playerMovement);
        print(_playerMovement._inputReader);
        _playerMovement._inputReader.OnMoveAnimationEvnet += AnimationMoveHandle;
    }

    void OnDestroy()
    {
        _playerMovement._inputReader.OnMoveAnimationEvnet -= AnimationMoveHandle;
    }

    void OnDisable()
    {
        _playerMovement._inputReader.OnMoveAnimationEvnet -= AnimationMoveHandle;
    }

    private void AnimationMoveHandle(bool state)
    {
        if (state)
        {
            _sprite.flipX = false;
            _isFlip = true;  // 오른쪽
        }
        else
        {
            _sprite.flipX = true;
            _isFlip = false; // 왼쪽
        }
    }

    public void AnimationEnd()
    {
        _player.StateMachine.CurrentState.AnimationFinshTrigger();
    }

    public void HandleStartChAttckAnim()
    {
        _playerMovement.isCharge = true;
    }

    public void HandleChargeAttackAnim()
    {
        _playerMovement.MoveChargeAttack(_isFlip);
        _playerMovement.isChargeAttack = true;
    }

    public void HandleEndChargeAttackAnim()
    {
        _playerMovement.IsAttack = false;
        _playerMovement.isCharge = false;
        _playerMovement.EndChargeAttack();
    }

    public void EndChargeAttack()
    {
        _playerMovement.IsAttack = false;
        _playerMovement.EndChargeAttackRay();
    }

    public void StartAttack()
    {
        _playerMovement.IsAttack = true;
    }

    public void EndAttack()
    {
        _playerMovement.IsAttack = false;
        _playerMovement.EndChargeAttackRay();
    }

}