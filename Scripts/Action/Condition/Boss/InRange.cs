using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class InRange : Conditional
{
	[SerializeField] private float _attackRange;
	private SharedTransform _playerTrm;

	public override void OnAwake()
    {
        _playerTrm = SharedValueManager.Instance.PlayerTrm;
    }
	
	public override TaskStatus OnUpdate()
	{
		float dis = Mathf.Abs((Owner.transform.position - _playerTrm.Value.position).x);
		if(dis <= _attackRange){
            Owner.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return TaskStatus.Success;
        } 
		else return TaskStatus.Failure;
	}

    // public override void OnDrawGizmos()
    // {
    //     base.OnDrawGizmos();
	// 	Gizmos.color = Color.red;
	// 	Gizmos.DrawWireSphere(Owner.transform.position, _attackRange);
    // }
}