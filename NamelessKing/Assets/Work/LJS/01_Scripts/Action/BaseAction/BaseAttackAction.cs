using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using LJS;
using UnityEngine.UIElements;

public enum AttackType
{
    Melee,
	Ranger,
    Magic
}

public class BaseAttackAction : Action, IShowGizmos
{
    [Header("attackSetting")]
	[SerializeField] private AttackType _attackType;
    [SerializeField] private EnemyInfoSO _enemyInfoSO;

    [Header("OverlapSetting")]
    [SerializeField] private bool _showGizoms;
    [SerializeField] private Vector2 _size;
    [SerializeField] private float _rayDistance;
    [SerializeField] private SharedTransform _attackTrm;
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private Transform _visualTrm;
    [SerializeField] private float _magicAttackRadius;

    private Vector3 direction;
    private float _attackCoolTime;

    // public override void OnAwake()
    // {
    //     AnimatorManager.Instance.AddAnimationAction(ActionType.AttackHit, "HitAction", HitAction);
    // }

    public override void OnStart()
    {
        _attackCoolTime = _enemyInfoSO._enemyInfo.attackCoolTime;
    }

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Success;
    }

    private Collider2D CheckLayer(AttackType type)
    {
        direction = Owner.transform.right * Owner.transform.localScale.x;
        switch (type)
        {
            case AttackType.Melee:
                return Physics2D.OverlapBox(new Vector3(_attackTrm.Value.position.x * 
                    _visualTrm.localScale.x, _attackTrm.Value.position.y,
                    _attackTrm.Value.position.z), _size, 0, _whatIsPlayer);
            case AttackType.Ranger:
                return Physics2D.Raycast(_attackTrm.Value.position, direction, 
                    _rayDistance, _whatIsPlayer).collider;
            case AttackType.Magic:
                return null;
            default:
                return null;
        }
    }

    public void HitAction(){
        
        Collider2D col = CheckLayer(_attackType);
        if(col){
            // if(TryGetComponent(플레이어 맞았을때 가져올 스크립트 : 이름)){
            //      맞았을 때 실행시킬 코드;
            // }
            _enemyInfoSO._enemyInfo.currentCoolTime = Time.time;      
        }      
    }

    public override void OnDrawGizmos()
    {
        if(!ShowGizoms()) return;
        float dirX = Mathf.Clamp(Owner.transform.localScale.x, -1, 1);
        direction = Owner.transform.right * dirX;
        base.OnDrawGizmos();
        switch (_attackType)
        {
            case AttackType.Melee:
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(new Vector3(_attackTrm.Value.position.x * 
                    _visualTrm.localScale.x, _attackTrm.Value.position.y,
                    _attackTrm.Value.position.z), _size);
                break;
            case AttackType.Ranger:
                Gizmos.color = Color.blue;
                Gizmos.DrawRay(_attackTrm.Value.position, direction);
                break;
            case AttackType.Magic:
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(Owner.transform.position, _magicAttackRadius);
                break;
        }
    }

    public bool ShowGizoms()
    {
        // Debug.Log($"this Script Gizoms State is{_showGizoms}");
        return _showGizoms;
    }
}