using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Player _player;
    private PlayerMovement _playerMovement;
    private Collider2D _collider;
    private LayerMask[] _layer;

    void Awake()
    {
        _layer = new LayerMask[2];
        _layer[0] = 0;  // Default
        _layer[1] = 6;  // Ground

        _player = PlayerManager.Instance.Player;
        _playerMovement = _player.GetComponent<PlayerMovement>();
        _collider = GetComponent<Collider2D>();

        if (_collider == null)
        {
            Debug.LogError("Missing Collider Plase Check Error Message and add Collider");
        }

    }

    void Update()
    {
        if (_player == null) return;

        if (_playerMovement.isDown)
        {
            gameObject.layer = _layer[0];  // 바닥이 아닌 레이어로 변경
            _collider.isTrigger = true;  // 바닥 뚫림
        }
        else if (_playerMovement.isFall)
        {
            gameObject.layer = _layer[1];  // 바닥 레이어로 변경해서 점프 가능
            _collider.isTrigger = false;  // 바닥 안 뚫림
        }
        else
        {
            gameObject.layer = _layer[0];  // 바닥이 아닌 레이어    로 변경
            _collider.isTrigger = true;  // 바닥 뚫림
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Exit Collider
        if (other.gameObject.CompareTag("Player"))
        {
            _playerMovement.StopDown();
            gameObject.layer = _layer[1];  // 바닥 레이어
            _collider.isTrigger = false; // 바닥
        }
    }
}
