using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "SO/InputReader")]
public class InputReader : ScriptableObject, PlayerInputcontrol.IPlayerActions
{
    public PlayerInputcontrol _playerActions;
    //public event Action<Vector2> OnMovementEvent;
    public event Action OnAttackEvent;
    public event Action OnJumpEvent;

    public event Action<bool> OnMoveAnimationEvnet;

    public event Action OnStartChargeEvent;
    public event Action<bool> OnMaxChargeEvent;

    private void OnEnable()
    {
        if (_playerActions == null)
        {
            _playerActions = new PlayerInputcontrol();
            _playerActions.Player.SetCallbacks(this);
        }

        _playerActions.Player.Enable();  //Active Input
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (Keyboard.current.aKey.isPressed)
        {
            OnMoveAnimationEvnet?.Invoke(false);
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            OnMoveAnimationEvnet?.Invoke(true);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        OnAttackEvent?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        OnJumpEvent?.Invoke();
    }

    public void OnFall(InputAction.CallbackContext context)
    {
        // s 키
        // 아무것도 안함
    }

    public void OnChargeAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnStartChargeEvent?.Invoke();
        }
        if (context.performed)
        {
            Debug.Log("홀드");
            OnMaxChargeEvent?.Invoke(true);

        }
        if (context.canceled)
        {
            OnMaxChargeEvent?.Invoke(false);
        }
    }
}
