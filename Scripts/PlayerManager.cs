using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : StudySingleton<PlayerManager>
{
    private Transform _playerTrm = null;

    public Transform PlayerTrm
    {
        get
        {
            if (_playerTrm == null)
            {
                _playerTrm = GameObject.FindGameObjectWithTag("Player").transform;
                if (_playerTrm == null)
                    Debug.LogError("Player does not exists but still try access it");
            }

            return _playerTrm;
        }
    }

    private Player _player;
    public Player Player
    {
        get
        {
            if (_player == null)
            {
                _player = PlayerTrm.GetComponent<Player>();
            }
            return _player;
        }
    }

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        _playerTrm = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
