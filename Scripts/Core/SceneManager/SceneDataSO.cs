using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/SceneSO")]
public class SceneDataSO : ScriptableObject
{
    public SceneInfo[] info;
}

[Serializable]
public class SceneInfo
{
    public string Name;
    [TextArea]
    public string Info;
}
