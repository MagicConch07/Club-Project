using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime.Tasks;
using CYH;
using UnityEngine;

public class BossAttackAction1 : Action
{
    [SerializeField] private Animator _animator;

    public override void OnStart(){
        AnimationManager.Instance.ChangeAnimationBool(_animator, "Attack1");
    }
}
