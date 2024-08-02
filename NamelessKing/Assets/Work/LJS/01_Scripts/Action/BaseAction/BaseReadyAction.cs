using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class BaseReadyAction : Action
{
	private Rigidbody2D rg;


	public override void OnStart()
	{
		rg = Owner.GetComponent<Rigidbody2D>();
	}

	public override TaskStatus OnUpdate()
	{
		rg.velocity = new Vector2(0, rg.velocity.y);
		return TaskStatus.Success;
	}
}