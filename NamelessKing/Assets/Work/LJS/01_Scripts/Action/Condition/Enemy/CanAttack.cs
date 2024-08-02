using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CanAttack : Conditional
{
    [SerializeField]
	private EnemyInfoSO _enemyInfo;
    [SerializeField] private SharedBool _canReady;

    private Animator _animator;

    public override void OnAwake()
    {
        base.OnAwake();
        _animator = Owner.transform.Find("Visual").GetComponent<Animator>();
    }

    public override TaskStatus OnUpdate()
	{
        if(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1){
            _canReady = false;
            return TaskStatus.Failure;
        }     
        _canReady = false;   

        float currentCoolTime =  _enemyInfo._enemyInfo.currentCoolTime;
        float attackCoolTime = _enemyInfo._enemyInfo.attackCoolTime;

        if (currentCoolTime == 0) return TaskStatus.Success;
        
        if(Time.time - currentCoolTime < attackCoolTime)
        {
            _canReady = true;
            return TaskStatus.Failure;
        }
        else
        {
            return TaskStatus.Success;
        }
	}
}