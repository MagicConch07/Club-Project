using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CanReady : Conditional
{
	[SerializeField] private SharedBool _canReady;
	public override TaskStatus OnUpdate()
	{
		if(_canReady.Value)
			return TaskStatus.Success;

		return TaskStatus.Failure;
	}
}