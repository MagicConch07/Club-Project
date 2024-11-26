using UnityEngine;
using BehaviorDesigner.Runtime;

public enum EnemyStateType{
	Attack,
	Chase,
	Roming,
	Death,
	Ready
}

[System.Serializable]
public class EnemyState
{
	[field:SerializeField] public EnemyStateType enemyStateType;
}

[System.Serializable]
public class SharedEnemyState : SharedVariable<EnemyState>
{
	public override string ToString() { return mValue == null ? "null" : mValue.ToString(); }
	public static implicit operator SharedEnemyState(EnemyState value) { return new SharedEnemyState { mValue = value }; }
}