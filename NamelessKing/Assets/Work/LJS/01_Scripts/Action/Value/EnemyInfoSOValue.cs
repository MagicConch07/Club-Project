using UnityEngine;
using BehaviorDesigner.Runtime;

[System.Serializable]
public class nfoSOValue
{
	[field: SerializeField] public EnemyInfoSO enemyInfoSO { get; set; }
}

[System.Serializable]
public class EnemyInfoSOValue : SharedVariable<nfoSOValue>
{
	public override string ToString() { return mValue == null ? "null" : mValue.ToString(); }
	public static implicit operator EnemyInfoSOValue(nfoSOValue value) { return new EnemyInfoSOValue { mValue = value }; }
}