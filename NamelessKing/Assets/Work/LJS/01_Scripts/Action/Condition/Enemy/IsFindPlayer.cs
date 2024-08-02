using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IsFindPlayer : Conditional
{
    private FieldOfView _fieldOfView;

    public override void OnStart()
    {
        _fieldOfView = Owner.GetComponent<FieldOfView>();
    }

    public override TaskStatus OnUpdate()
    {
        if(_fieldOfView.IsViewPlayer) return TaskStatus.Success;
		else return TaskStatus.Failure;
    }
}
