using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class BossChaseAction : Action
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _rigid2d;

    public override void OnStart()
    {
        _rigid2d = GetComponent<Rigidbody2D>();
    }

    public override TaskStatus OnUpdate()
    {
        Vector3 ownerPos = Owner.transform.position;
        Vector3 playerPos = SharedValueManager.Instance.PlayerTrm.Value.position;

        Vector3 dirX = new Vector3(playerPos.x - ownerPos.x, 0, 0);

        ChaseAction(dirX);

        return TaskStatus.Success;
    }

    public void ChaseAction(Vector3 dir){
        if(dir.magnitude > 0.5f)
        {
            _rigid2d.velocity = new Vector2(dir.normalized.x * moveSpeed, _rigid2d.velocity.y);        
        }
        else _rigid2d.velocity = new Vector2(0, _rigid2d.velocity.y);
        
        transform.localScale = new Vector3 (dir.normalized.x < 0 ? -1.5f : 1.5f, transform.localScale.y,
                    transform.localScale.z);
    }
}
