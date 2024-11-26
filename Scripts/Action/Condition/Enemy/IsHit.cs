using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class IsHit : Action
{
	private EnemyHealth _enemyHealth;
	public override void OnStart()
	{
		_enemyHealth = Owner.GetComponent<EnemyHealth>();
	}

	public override TaskStatus OnUpdate()
	{
		if(_enemyHealth.IsHit) return TaskStatus.Success;
		else return TaskStatus.Failure;
	}
}