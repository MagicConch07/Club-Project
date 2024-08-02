using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using Unity.VisualScripting;

public class BaseHitAction : Action
{
	private EnemyHealth _enemyHealth;
    private FieldOfView _fov;

    public override void OnAwake()
    {
        _enemyHealth = Owner.GetComponent<EnemyHealth>();
        _fov = Owner.GetComponent<FieldOfView>();
    }

    public override void OnStart()
    {
        _fov.IsViewPlayer = true;
        _enemyHealth.StartHitAction();
    }
    public override TaskStatus OnUpdate()
	{
		return TaskStatus.Success;
	}
}