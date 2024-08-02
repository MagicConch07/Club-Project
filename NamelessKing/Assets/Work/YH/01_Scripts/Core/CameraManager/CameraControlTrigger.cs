using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanDirection {
    Up,
    Down,
    Left,
    Right
}

[Serializable]
public class CustomInspectorObj {
    public bool swapCamera = false;
    public bool panCameraOnContect = false;

    [HideInInspector] public CinemachineVirtualCamera cameraOnLeft;
    [HideInInspector] public CinemachineVirtualCamera cameraOnRight;

    [HideInInspector] public PanDirection panDirection;
    [HideInInspector] public float panDistance = 3f;
    [HideInInspector] public float panTime = 0.4f;
}

public class CameraControlTrigger : MonoBehaviour {
    public CustomInspectorObj inspectorObj;
    private Collider2D _collider;

    private void Awake() {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent<Player>(out Player player)){
            if (inspectorObj.panCameraOnContect) {
                CameraManager.Instance.PanCameraOnContact(inspectorObj.panDistance, inspectorObj.panTime,inspectorObj.panDirection ,false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.TryGetComponent<Player>(out Player player)){
            if (inspectorObj.panCameraOnContect) {
                CameraManager.Instance.PanCameraOnContact(inspectorObj.panDistance, inspectorObj.panTime, inspectorObj.panDirection, true);
            }

            Vector2 exitDirection = (other.transform.position - _collider.transform.position).normalized;
            if(inspectorObj.swapCamera && inspectorObj.cameraOnLeft!=null&& inspectorObj.cameraOnRight != null) {
                CameraManager.Instance.SwapCamera(inspectorObj.cameraOnLeft, inspectorObj.cameraOnRight, exitDirection);
            }
        }
    }
}
