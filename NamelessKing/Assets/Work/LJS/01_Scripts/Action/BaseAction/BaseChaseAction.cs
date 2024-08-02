using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public enum ChaseType{
    Ground,
    Fly
}

public class BaseChaseAction : Action
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private ChaseType _chaseType;
    private Rigidbody2D rigid2d;

    public override void OnStart()
    {
        rigid2d = Owner.GetComponent<Rigidbody2D>();
    }

    public override TaskStatus OnUpdate()
	{
		Vector3 ownerPos = Owner.transform.position;
        Vector3 playerPos = SharedValueManager.Instance.PlayerTrm.Value.position;

        Vector3 dirX = new Vector3(playerPos.x - ownerPos.x, 0, 0);
        Vector3 dir = playerPos - ownerPos;

        switch(_chaseType){
            case ChaseType.Ground:
                ChaseGroundEnemy(dirX);
                break;
            case ChaseType.Fly:
                ChaseFlyEnemy(dir);
                break;
        }
            

        // Owner.transform.localScale = new Vector3(Owner.transform.localScale.x  * dir.normalized.x, 
        //     Owner.transform.localScale.y, Owner.transform.localScale.z);

        return TaskStatus.Success;
	}

    public void ChaseGroundEnemy(Vector3 dir){
        if(dir.magnitude > 0.5f)
        {
            rigid2d.velocity = new Vector2(dir.normalized.x * moveSpeed, rigid2d.velocity.y);        
        }
        else rigid2d.velocity = new Vector2(0, rigid2d.velocity.y);
        
        transform.localScale = new Vector3 (dir.normalized.x < 0 ? -1f : 1f, transform.localScale.y,
                    transform.localScale.z);
    }

    public void ChaseFlyEnemy(Vector3 dir){
        if(dir.magnitude > 0.5f)
        {
            rigid2d.velocity = new Vector2(dir.normalized.x * moveSpeed, dir.normalized.y * moveSpeed);        
        }
        else rigid2d.velocity = new Vector2(0, 0);

        transform.localScale = new Vector3 (dir.normalized.x < 0 ? -1f : 1f, transform.localScale.y,
                    transform.localScale.z);
    }
}