using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class InGround : Conditional
{
    [SerializeField] private float _rayDistance;
    [SerializeField] private LayerMask _whatIsGround;
    [SerializeField] private SharedTransform _footTrm;
    
    private Rigidbody2D _rigid2d;

    public override void OnAwake()
    {
        base.OnAwake();
        _rigid2d = GetComponent<Rigidbody2D>();
    }

    public override TaskStatus OnUpdate()
    {
        if(CheckGround()){
            return TaskStatus.Success;
        }
        else{
            _rigid2d.velocity = Vector2.zero;
            return TaskStatus.Failure;
        }
    }

    private Collider2D CheckGround(){
        Vector3 dir = ((Owner.transform.right * Owner.transform.localScale.x) + -Owner.transform.up).normalized;
        return Physics2D.Raycast(_footTrm.Value.position, dir, _whatIsGround).collider;
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;
        Vector3 dir = ((Owner.transform.right * Owner.transform.localScale.x) + -Owner.transform.up).normalized;
        Gizmos.DrawRay(_footTrm.Value.position, dir);
    }
}
