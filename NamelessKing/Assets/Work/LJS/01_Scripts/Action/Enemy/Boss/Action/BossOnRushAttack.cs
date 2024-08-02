using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class BossOnRushAttack : Action
{
	[SerializeField] private float _onRushRange;
	[SerializeField] private GameObject _warningLine;
	public override void OnStart()
	{
		
	}

	public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}