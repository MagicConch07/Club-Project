using System;
using System.Collections;
using UnityEngine;

public class PlayerFollowObject : MonoBehaviour {
    [Header("Reference")]
    [SerializeField] private Transform _playerTrm;

    [Header("Flip rotation setting")]
    [SerializeField] private float _flippingTime = 0.5f;

    private Coroutine _turnCorutine;

    private Player _player;

    private void Awake() {
        _player = _playerTrm.GetComponent<Player>();
        //_player.OnFlip += HandleFlipEvent;
    }
    private void OnDestroy() {
        if (_player == null) {
            return;
        }
        //_player.OnFlip -= HandleFlipEvent;
    }
    private void Update() {
        transform.position = _playerTrm.position;
    }

    private void HandleFlipEvent(int facingDirection) {
        if(_turnCorutine != null) {
            StopCoroutine(_turnCorutine);
        }

        _turnCorutine = StartCoroutine(FlipYLerp(facingDirection));
    }

    private IEnumerator FlipYLerp(int facingDirection) {
        float startRotation = transform.localEulerAngles.y;
        float endRotationAmount = DetermineEndRotation(facingDirection);
        float yRotation = 0;

        float elapsedTime = 0f; //경과시간
        
        float totaltime = _flippingTime * Mathf.Abs(endRotationAmount - startRotation) / 180; // 남은 각도에 비례하여 시간 결정(비례식)

        while (elapsedTime < totaltime) {
            elapsedTime += Time.deltaTime;
            yRotation = Mathf.Lerp(startRotation, endRotationAmount, elapsedTime / totaltime);
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
            yield return null;
        }
    }
    private float DetermineEndRotation(int direction) => direction == 1 ? 0f : 180f;

    private void OnValidate() {
        if (_player != null) {
            transform.position = _playerTrm.position;
        }
    }

}
