using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Text")]
public class TextSO : ScriptableObject
{
    public Texts[] text;
}

[Serializable]
public class Texts
{
    public string Name;
    [TextArea]
    public string Info;
}
