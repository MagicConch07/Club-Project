using Cinemachine;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraControlTrigger))]
public class CameraControlEditor : Editor {
    private CameraControlTrigger _trigger;

    private void OnEnable() {
        _trigger = target as CameraControlTrigger;
    }
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        CustomInspectorObj inspectorObj = _trigger.inspectorObj;
        if (inspectorObj.swapCamera) {
            inspectorObj.cameraOnLeft = EditorGUILayout.ObjectField("Camera on Left", 
                inspectorObj.cameraOnLeft, typeof(CinemachineVirtualCamera), 
                true)as CinemachineVirtualCamera;
            inspectorObj.cameraOnRight = EditorGUILayout.ObjectField("Camera on Right",
                inspectorObj.cameraOnRight, typeof(CinemachineVirtualCamera),
                true) as CinemachineVirtualCamera;
        }
        if (inspectorObj.panCameraOnContect) {
            inspectorObj.panDirection =
                (PanDirection)EditorGUILayout.EnumPopup("Camera moveing direction", inspectorObj.panDirection);
            inspectorObj.panDistance =
                EditorGUILayout.FloatField("Camera moveing distance", inspectorObj.panDistance);
            inspectorObj.panTime =
                EditorGUILayout.FloatField("Camera moveing time", inspectorObj.panTime);
        }

        if(GUI.changed) {
            EditorUtility.SetDirty(_trigger); // 값 변화시 다시 그려라
        }
    }
}
