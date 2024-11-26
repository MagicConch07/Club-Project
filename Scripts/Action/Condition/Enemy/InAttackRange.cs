using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class InAttackRange : Conditional
{
    [SerializeField] private AttackType currnetAttackType;
    [SerializeField] private float MeleeattackRange;
    [SerializeField] private float RangerattackRange;
    [SerializeField] private float MagicAttackRange;
    private SharedTransform playerTrm;

    private float attackRange;

    public override void OnAwake()
    {
        playerTrm = SharedValueManager.Instance.PlayerTrm;
    }

    public override TaskStatus OnUpdate()
    {
        switch (currnetAttackType)
        {
            case AttackType.Melee:
                attackRange = MeleeattackRange;
                break;
            case AttackType.Ranger:
                attackRange = RangerattackRange;
                break;
            case AttackType.Magic:
                attackRange = MagicAttackRange;
                break;
            default:
                break;
        }

        float dis = Mathf.Abs((Owner.transform.position - playerTrm.Value.position).x);
        if (dis <= attackRange)
        {
            Owner.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return TaskStatus.Success;
        }
        else return TaskStatus.Failure;
    }
}