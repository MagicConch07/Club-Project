using UnityEngine;
using BehaviorDesigner;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.ObjectDrawers;

public class InPlatform : Conditional
{
	[SerializeField] private LayerMask _whatisGround;
	[SerializeField] private float _distance;
	[SerializeField] private SharedTransform _footTrm;

	private Vector3 _rayOrigin;

    public override TaskStatus OnUpdate()
	{
		_rayOrigin = new Vector3(_footTrm.Value.transform.position.x,
		_footTrm.Value.transform.position.y);

        if (Physics2D.Raycast(_rayOrigin, -Owner.transform.up, _distance, _whatisGround))
		{
            return TaskStatus.Success;
        }

        return TaskStatus.Failure;

	}

	public override void OnDrawGizmos()
	{
		_rayOrigin = new Vector3(_footTrm.Value.transform.position.x,
		_footTrm.Value.transform.position.y);

		Gizmos.color = Color.green;
		Gizmos.DrawRay(new Ray(_rayOrigin, -Owner.transform.up));
		// Gizmos.DrawLine(_footTrm.Value.transform.position, 
		// 			new Vector3(_footTrm.Value.transform.position.x, _footTrm.Value.transform.position.y + _distance,
		// 						_footTrm.Value.transform.position.z));
	}
}