using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBackGround : MonoBehaviour
{
    [SerializeField] private Vector2 _ratio;
    [SerializeField] private bool _yAxisRepeat = false;

    [SerializeField] private Transform _maincamTrm;
    private Vector2 _initPosition;
    private Vector2 _spriteSize;
    private Vector2 _camInitPosition;

    private void Awake()
    {
        _camInitPosition = _maincamTrm.position;
        _initPosition = transform.position;
        _spriteSize = GetComponent<SpriteRenderer>().bounds.size;
    }

    private void LateUpdate()
    {
        MainToCameraMove();
    }

    private void MainToCameraMove()
    {
        Vector2 cameraDelta = (Vector2)_maincamTrm.position - _camInitPosition;

        Vector2 moveOffset = new Vector2(cameraDelta.x * _ratio.x, cameraDelta.y * _ratio.y);
        transform.position = _initPosition + moveOffset;

        Vector2 deltaFromCam = _maincamTrm.position - transform.position;

        if (deltaFromCam.x > _spriteSize.x)  // 오른쪽으로 이동한 거고
        {
            _initPosition.x += _spriteSize.x;
        }
        else if (deltaFromCam.x < -_spriteSize.x)  // 왼쪽으로 그림한장 크기만큼 벌어진거
        {
            _initPosition.x -= _spriteSize.x;
        }

        if (_yAxisRepeat)
        {
            if (deltaFromCam.y > _spriteSize.y)  // 위쪽으로 이동한 거고
            {
                _initPosition.y += _spriteSize.y;
            }
            else if (deltaFromCam.y < -_spriteSize.y)  // 아래쪽으로 그림한장 크기만큼 벌어진거
            {
                _initPosition.y -= _spriteSize.y;
            }
        }
    }
}

